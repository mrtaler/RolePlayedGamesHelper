using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Autofac;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RolePlayedGamesHelper.Cqrs.EventSourcing.GurpsAssistant.Seedwork.EventSourcing.Persistence;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.EventSourcing
{
  public class GurpsAssistantSeedworkEventSourcingModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(x =>
      {
        var cnStr = x.Resolve<IConfiguration>().Get<AzureTablesEventSourcingOptions>().StorageConnectionString;
        //  var connectionString = x.Resolve<IKeyVault>().GetSecretStringAsync(nameof(AppSettings.StorageConnectionString)).GetAwaiter().GetResult();
        //    var connectionString = appSettings.Storage.ConnectionString;
        //  var cnStr = "DefaultEndpointsProtocol=https;AccountName=samentoring2019;AccountKey=PUhXnMYHImsAZ4XEbOhrolpH3EFxAPToUDtunoHaCTyoDiW833ls58CR2wEpu9IJs2Lwjpqfzni9oqMJ6rPoOA==;EndpointSuffix=core.windows.net";
        //  var cnStr =
        //    "DefaultEndpointsProtocol=https;AccountName=gurpsassistantdiag;AccountKey=cR55mn5c8OPyUWlNa972/Zr7ExWmFJZu7rWNfUf4ylDCCaalsOtGS5MGoqDCuFGBF93mHXWyOCb8TcWzUwASrw==;EndpointSuffix=core.windows.net";
        var storageAccount = CloudStorageAccount.Parse(cnStr);
        OptimizeTableConnection(storageAccount);
        return storageAccount;
      }).SingleInstance();

      builder.Register(
          provider => provider.Resolve<CloudStorageAccount>().CreateCloudTableClient())
          .SingleInstance();

      builder.Register<IDictionary<string, CloudTable>>(provider =>
      {
        var client = provider.Resolve<CloudTableClient>();
        var result = new Dictionary<string, CloudTable>
                 {
                    {"eventstore", client.GetTableReference("eventstore")},
                 };
        return result;
      }).SingleInstance();



      builder.RegisterType<EventStore>().As<IStoreProvider>().InstancePerLifetimeScope();
      //builder.RegisterType<EventPublisher>().As<IEventPublisher>();

      //    builder.RegisterGeneric(typeof(AggregateRepository<,>)).As(typeof(IAggregateRepository<,>));
    }

    private static void OptimizeTableConnection(CloudStorageAccount storageAccount)
    {
      var tableServicePoint = ServicePointManager.FindServicePoint(storageAccount.TableEndpoint);
      tableServicePoint.UseNagleAlgorithm = false;
      tableServicePoint.Expect100Continue = false;
      tableServicePoint.ConnectionLimit = 100;
    }
  }
}
