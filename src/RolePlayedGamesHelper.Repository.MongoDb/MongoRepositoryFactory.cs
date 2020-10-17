using System;
using MongoDB.Driver;
using RolePlayedGamesHelper.Repository.MongoDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.MongoDb
{
    public class MongoRepositoryFactory : RepositoryFactoryBase<MongoDbContextFactory, IMongoClient>
    {
        public MongoRepositoryFactory(MongoDbContextFactory dataContextFactory) : base(dataContextFactory)
        {
        }

        /// <inheritdoc />
        public override IRepository<T> GetInstance<T>() => throw new NotImplementedException();


        /// <inheritdoc />
        public override IRepository<T, TKey> GetInstance<T, TKey>()
        {
                var collection = DataContextFactory
                                 .GetContext()
                                 .GetDatabase(DataContextFactory.dbConfiguration.DatabaseName)
                                 .GetCollection<T>(typeof(T).Name);
                return new MongoDbRepository<T, TKey>(collection);
        }

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>() => throw new NotImplementedException();

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2, TKey3> GetInstance<T, TKey, TKey2, TKey3>() => throw new NotImplementedException();
    }
}
