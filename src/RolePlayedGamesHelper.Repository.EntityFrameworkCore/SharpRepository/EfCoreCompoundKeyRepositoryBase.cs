﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RolePlayedGamesHelper.Repository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;

namespace RolePlayedGamesHelper.Repository.EntityFrameworkCore.SharpRepository
{
    public class EfCoreCompoundKeyRepositoryBase<T> : LinqCompoundKeyRepositoryBase<T>
        where T : class
       
    {
        protected DbSet<T> DbSet { get; private set; }
        private ICoreDbContext context;


        internal EfCoreCompoundKeyRepositoryBase(ICoreDbContext contextFactory, ICompoundKeyCachingStrategy<T> cachingStrategy = null)
            : base(cachingStrategy)
        {
            this.context = contextFactory;
            DbSet        = context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            // no generating primary keys
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void UpdateItem(T entity)
        {
            var entry = context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                object[] keys;

                if (GetPrimaryKeys(entity, out keys))
                {
                    // check to see if this item is already attached
                    //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                    //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                    var attachedEntity = context.Set<T>().Find(keys);
                    if (attachedEntity != null)
                    {
                        context.Entry(attachedEntity).CurrentValues.SetValues(entity);
                        return;
                    }
                }
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
        protected override T GetQuery(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (context == null) return;

            context.Dispose();
            //    DataContext = null;
        }
    }

    public class EfCoreCompoundKeyRepositoryBase<T, TKey, TKey2> : LinqCompoundKeyRepositoryBase<T, TKey, TKey2>
        where T : class
    {
        protected DbSet<T> DbSet { get; private set; }
        private ICoreDbContext context;


        internal EfCoreCompoundKeyRepositoryBase(ICoreDbContext contextFactory, ICompoundKeyCachingStrategy<T, TKey, TKey2> cachingStrategy = null)
            : base( cachingStrategy)
        {
            this.context = contextFactory;
            DbSet        = context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void UpdateItem(T entity)
        {
            var entry = context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                TKey key;
                TKey2 key2;

                if (GetPrimaryKey(entity, out key, out key2))
                {
                    // check to see if this item is already attached
                    //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                    //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                    var attachedEntity = context.Set<T>().Find(key, key2);
                    if (attachedEntity != null)
                    {
                        context.Entry(attachedEntity).CurrentValues.SetValues(entity);

                        return;
                    }
                }
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
        protected override T GetQuery(TKey key, TKey2 key2)
        {
            return DbSet.Find(key, key2);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (context == null) return;

            context.Dispose();
            //Context = null;
        }
    }

    public class EfCoreCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> : LinqCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3>
        where T : class
    {
        protected DbSet<T> DbSet { get; private set; }
        private ICoreDbContext context;

        internal EfCoreCompoundKeyRepositoryBase(ICoreDbContext contextFactory, ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> cachingStrategy = null)
            : base( cachingStrategy)
        {
            this.context = contextFactory;
            DbSet        = context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void UpdateItem(T entity)
        {
            var entry = context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                TKey key;
                TKey2 key2;
                TKey3 key3;

                if (GetPrimaryKey(entity, out key, out key2, out key3))
                {
                    // check to see if this item is already attached
                    //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                    //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                    var attachedEntity = context.Set<T>().Find(key, key2, key3);
                    if (attachedEntity != null)
                    {
                        context.Entry(attachedEntity).CurrentValues.SetValues(entity);
                        return;
                    }
                }
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
        protected override T GetQuery(TKey key, TKey2 key2, TKey3 key3)
        {
            return DbSet.Find(key, key2, key3);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (context == null) return;

            context.Dispose();
            context = null;
        }
    }
}
