using Autofac;
using RolePlayedGamesHelper.Repository.IntegrationTests.Context.Modules;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Assert;
using RolePlayedGamesHelper.Repository.RavenDb;
using System;
using Xunit;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Context
{
  public class RavenContextTest : TestBase
  {
    private readonly IContainer container;

    public RavenContextTest()
    {
      var buider = new ContainerBuilder();
      buider.RegisterModule<RavenContextTestModule>();
      container = buider.Build();

    }

    [SkippableFact]
    public void RavenDbContextTest()
    {
      Skip.IfNot(Environment.OSVersion.VersionString.Contains("Windows"));
      var uow = container.Resolve<RavenUnitOfWork>();
      var repo = uow.GetRepository<Contact, string>();
      var repo1 = uow.GetRepository<EmailAddress, string>();
      //var repo = container.Resolve<IRepository<Contact>>();
      repo.Add(new Contact
      {
        ContactId = 1,
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
}
