using Autofac;
using MongoDB.Driver;
using RolePlayedGamesHelper.Repository.MongoDb;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Context
{
    public class MongoDbContextTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register((c) => new MongoDbConfiguration
                {
                    ConnectionString = "mongodb://admin:password@localhost:27017",
                    DatabaseName     = "TestMongoDB"
                })
                .AsSelf()
                .SingleInstance();

            builder
                .RegisterType<MongoDbContextFactory>()
                .AsSelf()
                .As<IDataContextFactory<IMongoClient>>().SingleInstance();

            builder.RegisterType<MongoDbUnitOfWork>().As<IUnitOfWork<IMongoClient, MongoDbContextFactory>>().AsSelf();
        }
    }
}