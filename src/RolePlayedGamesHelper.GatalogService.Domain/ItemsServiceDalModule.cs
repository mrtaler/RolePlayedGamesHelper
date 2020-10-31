using System.Security.Cryptography.X509Certificates;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.GatalogService.Domain
{
    /// <summary>
    /// The items service dal module.
    /// </summary>
    public class ItemsServiceDalModule : Module
    {
        /// <summary>
        /// The use in memory database.
        /// </summary>
        private readonly bool useInMemoryDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsServiceDalModule"/> class.
        /// </summary>
        /// <param name="useInMemoryDatabase">
        /// The use in memory database.
        /// </param>
        public ItemsServiceDalModule(bool useInMemoryDatabase)
        {
            this.useInMemoryDatabase = useInMemoryDatabase;
        }

        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
          builder
            .Register((c) =>
            {
              /* var x509 = new X509Store(StoreName.My, StoreLocation.LocalMachine);
               x509.Open(OpenFlags.ReadOnly);
               var certificateSt = x509.Certificates.Find(X509FindType.FindByThumbprint, "4eda9df28ca6a3e3d15e59e91ae18e345824c3af", false)[0];
               */
              var certificateSt = new X509Certificate2(@"C:\CD\Certs\Raven\TalerRavenAzure.pfx",
                                                       "123456789", X509KeyStorageFlags.MachineKeySet);

              var store = new DocumentStore
              {
                Urls        = new[] { "https://a.mrtaler.development.run" },
                Database    = "GurpsData",
                Conventions = { IdentityPartsSeparator = "-" },
                Certificate = certificateSt
              };
              return store.Initialize();
              ;
            })
            .As<IDocumentStore>()
            .SingleInstance();

          builder
            .Register(
              x =>
                new RavenDbContextFactory(x.Resolve<IDocumentStore>()))
            .AsSelf()
            .As<IDataContextFactory<IDocumentSession>>().SingleInstance();

          builder.RegisterType<RavenUnitOfWork>().As<IUnitOfWork<IDocumentSession, RavenDbContextFactory>>().AsSelf();

          
         /*
          // .As<IUnitOfWorkAsync>();

            builder.RegisterType<AmmoUpgratesRepository>()
                   .As<IRepository<AmmoUpgrades, int>>()
                   .As<IAmmoUpgradesRepository>();

             builder
                  .RegisterGeneric(typeof(RavenDbRepository<,>))
                  .As(typeof(IRepository<,>));

            builder
                  .RegisterType<AmmoUpgratesRepository>()
                  .As<IRepository<AmmoUpgrades>>()
                  .As<IAmmoUpgradesRepository>();*
            builder
                .RegisterType<AttachmentMountRepository>()
                .As<IRepository<AttachmentMount, int>>()
                .As<IAttachmentMountRepository>();
            builder
                .RegisterType<AttachmentRepository>()
                .As<IRepository<Attachment, int>>()
                .As<IAttachmentRepository>();
            builder
                .RegisterType<AttachmentSlotRepository>()
                .As<IRepository<AttachmentSlot, int>>()
                .As<IAttachmentSlotRepository>();
            builder
                .RegisterType<AvailableAttachSlotRepository>()
                .As<IRepository<AvailableAttachSlot, int>>()
                .As<IAvailableAttachSlotRepository>();
            builder
                .RegisterType<CaliberRepository>()
                .As<IRepository<Caliber, int>>()
                .As<ICaliberRepository>();
            builder
                .RegisterType<GurpsClassRepository>()
                .As<IRepository<GurpsClass, int>>()
                .As<IGurpsClassRepository>();
            builder
                .RegisterType<ItemClassRepository>()
                .As<IRepository<ItemClass, int>>()
                .As<IItemClassRepository>();
            builder
                .RegisterType<ItemRepository>()
                .As<IRepository<Item, int>>()
                .As<IItemRepository>();
            builder
                .RegisterType<ItemSubClassRepository>()
                .As<IRepository<ItemSubClass, int>>()
                .As<IItemSubClassRepository>();
            builder
                .RegisterType<LaserColorEfRepository>()
                .As<IRepository<LaserColorEf, int>>()
                .As<ILaserColorEfRepository>();
            builder
                .RegisterType<LegalityClassRepository>()
                .As<IRepository<LegalityClass, int>>()
                .As<ILegalityClassRepository>();
            builder
                .RegisterType<TechnicalLevelRepository>()
                .As<IRepository<TechnicalLevel, int>>()
                .As<ITechnicalLevelRepository>();
            builder
                .RegisterType<TypeOfBoxRepository>()
                .As<IRepository<TypeOfBox, int>>()
                .As<ITypeOfBoxRepository>();
            builder
                .RegisterType<TypeOfDamageRepository>()
                .As<IRepository<TypeOfDamage, int>>()
                .As<ITypeOfDamageRepository>();
            builder
                .RegisterType<WeaponAttackTypeRepository>()
                .As<IRepository<WeaponAttackType, int>>()
                .As<IWeaponAttackTypeRepository>();
            builder
                .RegisterType<WeaponDamageRepository>()
                .As<IRepository<WeaponDamage, int>>()
                .As<IWeaponDamageRepository>();
            builder
                .RegisterType<WeaponRepository>()
                .As<IRepository<Weapon, int>>()
                .As<IWeaponRepository>();*/
        }
    }
}
