using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using RolePlayedGamesHelper.Repository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;
using RolePlayedGamesHelper.Repository.SharpRepository.Helpers;

namespace RolePlayedGamesHelper.Repository.EntityFramework.SharpRepository
{
    public class EfRepositoryBase<T, TKey> : LinqRepositoryBase<T, TKey> 
        where T : class
    {
        protected IDbSet<T> DbSet { get; private set; }
        protected IEfDbContext Context { get; private set; }

        internal EfRepositoryBase(IEfDbContext dbContext, ICachingStrategy<T, TKey> cachingStrategy = null) : base(cachingStrategy)
        {
            this.Context = dbContext;
            DbSet        = Context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            if (typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string))
            {
                TKey id;
                if (GenerateKeyOnAdd && GetPrimaryKey(entity, out id) && Equals(id, default(TKey)))
                {
                    id = GeneratePrimaryKey();
                    SetPrimaryKey(entity, id);
                }
            }
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
          /* Self referencing entities with nullable keys will be set null during delete. 
           * If you have a partition on a self referencing nullable property then the later generated partition key will be incorrect 
           * causing the partition generation to fail to increment and the old deleted cache enteries will be returned from the cache. */

          var entry = Context.Entry<T>(entity);
          entry.State = EntityState.Detached;

          // Get an seperate attached entity.
          TKey key;
          if (GetPrimaryKey(entity, out key))
          {
            var attachedEntity = Context.Set<T>().Find(key);
            if (attachedEntity != null)
              DbSet.Remove(attachedEntity);
          }
        }

        protected override void UpdateItem(T entity)
        {
            var entry = Context.Entry<T>(entity);

            try
            {
                if (entry.State == EntityState.Detached)
                {

                    if (GetPrimaryKey(entity, out TKey key))
                    {
                        // check to see if this item is already attached
                        //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                        //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                        var attachedEntity = Context.Set<T>().Find(key);
                        if (attachedEntity != null)
                        {
                            Context.Entry(attachedEntity).CurrentValues.SetValues(entity);

                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // ignore and try the default behavior
            }

            // default
            entry.State = EntityState.Modified;
        }

        protected override IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null)
        {
            var query = DbSet.AsQueryable();
            return fetchStrategy == null ? query : fetchStrategy.IncludePaths.Aggregate(query, (current, path) => current.Include(path));
        }

        // we override the implementation fro LinqBaseRepository becausee this is built in and doesn't need to find the key column and do dynamic expressions, etc.
        //  this also provides the EF5 first level caching out of the box
        protected override T GetQuery(TKey key, IFetchStrategy<T> fetchStrategy)
        {
            return fetchStrategy == null ? DbSet.Find(key) : base.GetQuery(key, fetchStrategy);
        }

        protected override PropertyInfo GetPrimaryKeyPropertyInfo()
        {
            // checks for the Code First KeyAttribute and if not there do the normal checks
            var type = typeof(T);
            var keyType = typeof(TKey);

            return type.GetProperties().FirstOrDefault(x => x.HasAttribute<KeyAttribute>() && x.PropertyType == keyType)
                ?? base.GetPrimaryKeyPropertyInfo();
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context == null) return;

            Context.Dispose();
            Context = null;
        }

        protected virtual TKey GeneratePrimaryKey()
        {
            if (typeof(TKey) == typeof(Guid))
            {
                return (TKey)Convert.ChangeType(Guid.NewGuid(), typeof(TKey));
            }

            if (typeof(TKey) == typeof(string))
            {
                return (TKey)Convert.ChangeType(Guid.NewGuid().ToString(), typeof(TKey));
            }
            
            throw new InvalidOperationException("Primary key could not be generated. This only works for GUID, Int32 and String.");
        }
    }
}