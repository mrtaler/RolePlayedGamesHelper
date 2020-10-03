using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.RavenDb
{
    public class RavenDbRepositoryFactory : RepositoryFactoryBase<RavenDbContextFactory, IDocumentSession>
    {
        /// <inheritdoc />
        public RavenDbRepositoryFactory(RavenDbContextFactory dataContextFactory) : base(dataContextFactory)
        {
        }

        /// <inheritdoc />
        public override IRepository<T> GetInstance<T>()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override IRepository<T, TKey> GetInstance<T, TKey>()
        {
            var context = DataContextFactory.GetContext();
            return new RavenDbRepository<T, TKey>(context);
        }

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2, TKey3> GetInstance<T, TKey, TKey2, TKey3>()
        {
            throw new System.NotImplementedException();
        }

    }
}