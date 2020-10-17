using Autofac;
using RolePlayedGamesHelper.Repository.IntegrationTests.Context.Modules;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Assert;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Mongo;
using RolePlayedGamesHelper.Repository.MongoDb;
using Xunit;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Context
{
    public class MongoDbContextTest : TestBase
    {
        private readonly IContainer container;

        public MongoDbContextTest()
        {
            var buider = new ContainerBuilder();
            buider.RegisterModule<MongoDbContextTestModule>();
            container = buider.Build();

        }

        [Fact(Skip = "specific reason")]
        public void MongoContextTest()
        {
            var uow   = container.Resolve<MongoDbUnitOfWork>();
            var repo  = uow.GetRepository<ContactMongo, string>();
            var repo1 = uow.GetRepository<EmailAddressMongo, string>();
            //var repo = container.Resolve<IRepository<Contact>>();
            repo.Add(new ContactMongo
            {
                ContactId=2,
                Name = "str"

            });
            repo1.Add(new EmailAddressMongo()
            {
                ContactId = 2,
                Email = "123123@epam.com",
                EmailAddressId = 1,
                Label = "asdasd"
            });
            uow.SaveChanges();

            var tm1 = repo1.GetAll();




        }
    }
}
