using System.ComponentModel.DataAnnotations;
using Autofac;
using RolePlayedGamesHelper.Repository.RavenDb;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects.Assert;
using Xunit;

namespace RolePlayedGamesHelper.Repository.UnitTests.Context
{
    public class ContextTest : TestBase
    {
        private IContainer container;

        public ContextTest()
        {
            var buider = new ContainerBuilder();
            buider.RegisterModule<RavenContextTestModule>();
            container = buider.Build();

        }

        [Fact]
        public void Test1()
        {
            var uow  = container.Resolve<RavenUnitOfWork>();
            var repo = uow.GetRepository<Contact, string>();
            var repo1 = uow.GetRepository<EmailAddress, string>();
            //var repo = container.Resolve<IRepository<Contact>>();
            repo.Add(new Contact
            {
                ContactId=1,
                Name = "str"

            });
            repo1.Add(new EmailAddress
            {
                ContactId = 1,
                Email = "123123@epam.com",
                EmailAddressId = 1,
                Label = "asdasd"
            });
            uow.SaveChanges();

            var tm1 = repo1.GetAll();




        }
    }

  /*  public class EfCoreContextFactory : EfCoreDefaultDataContextFactory<TestObjectContextCore>
    {
        public EfCoreContextFactory()
        {
            _dataContext=new TestObjectContextCore(new DbContextOptionsBuilder<TestObjectContextCore>()
                                                   .UseInMemoryDatabase(databaseName: "Test")
                                                   .Options);
        }
    }*/
}
