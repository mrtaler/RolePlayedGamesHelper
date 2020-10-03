using MongoDB.Driver;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.MongoDb
{
    public sealed class MongoDbContextFactory : IDataContextFactory<IMongoClient>
    {
        private IMongoClient client;
        internal MongoDbConfiguration dbConfiguration;
        public MongoDbContextFactory(MongoDbConfiguration dbConfiguration)
        {
            this.dbConfiguration = dbConfiguration;
        }

        public IMongoClient GetContext()
        {
            if (client != null) return client;
            var openSession = new MongoClient(dbConfiguration.ConnectionString);
            client = openSession;
            return client;
        }
    }
}