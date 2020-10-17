using Autofac;
using RolePlayedGamesHelper.Repository.EntityFrameworkCore;
using RolePlayedGamesHelper.Repository.IntegrationTests.Context.Modules;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Assert;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;
using Xunit;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Context
{
    public class CoreInMemoryDbContextTest : TestBase
    {
        private readonly IContainer container;

        public CoreInMemoryDbContextTest()
        {
            var buider = new ContainerBuilder();
            buider.RegisterModule<ContextCoreTestModule>();
            container = buider.Build();

        }

        [Fact]
        public void CoreInMemoryContextTest()
        {
            var uow   = container.Resolve<IUnitOfWork<TestObjectContextCore, DbCoreContextFactory<TestObjectContextCore>>>();
            var repo  = uow.GetRepository<Contact, string>();
            var repo1 = uow.GetRepository<EmailAddress, string>();
            //var repo = container.Resolve<IRepository<Contact>>();
            repo.Add(new Contact
            {
                ContactId=2,
                Name = "str"

            });
            repo1.Add(new EmailAddress()
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
