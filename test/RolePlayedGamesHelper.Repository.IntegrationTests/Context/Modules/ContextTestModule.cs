using Autofac;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Context.Modules
{
    public class ContextTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            /*builder
               .Register(x => new EfCoreContextFactory()).
               As<IDataContextFactory<TestObjectContextCore>>()
               .SingleInstance();

           builder
               .RegisterType<UnitOfWork<TestObjectContextCore>>()
               .As<IUnitOfWork>()
               .InstancePerLifetimeScope();

           builder
               .RegisterType<EfCoreRepository<Contact, TestObjectContextCore>>()
               .As<IRepository<Contact>>()
               .InstancePerDependency();
*/
        }
    }
}