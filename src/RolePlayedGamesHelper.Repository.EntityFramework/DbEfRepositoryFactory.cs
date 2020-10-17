using System.Data.Entity;
using RolePlayedGamesHelper.Repository.EntityFramework.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.EntityFramework
{
    public class DbEfRepositoryFactory<TContext> : RepositoryFactoryBase<DbEfContextFactory<TContext>, DbContext>
        where TContext : DbContext, IEfDbContext
    {
        public DbEfRepositoryFactory(DbEfContextFactory<TContext> dataCoreContextFactory) : base(dataCoreContextFactory)
        {
        }

        /// <inheritdoc />
        public override IRepository<T> GetInstance<T>()
        {
            return new EfRepository<T>(DataContextFactory.GetContext());
        }

        /// <inheritdoc />
        public override IRepository<T, TKey> GetInstance<T, TKey>()
        {
            return new EfRepository<T, TKey>(DataContextFactory.GetContext());
        }

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>()
        {
            return new EfRepository<T, TKey, TKey2>(DataContextFactory.GetContext());
        }

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2, TKey3> GetInstance<T, TKey, TKey2, TKey3>()
        {
            return new EfRepository<T, TKey, TKey2, TKey3>(DataContextFactory.GetContext());
        }
    }
}