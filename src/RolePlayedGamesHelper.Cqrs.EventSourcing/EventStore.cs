using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.EventSourcing.Exception;
using RolePlayedGamesHelper.Cqrs.EventSourcing.Infrastructure;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RolePlayedGamesHelper.Cqrs.Kledex.Entities;
using RolePlayedGamesHelper.Cqrs.Kledex.Entities.Factories;
using Streamstone;

namespace RolePlayedGamesHelper.Cqrs.EventSourcing
{
    namespace GurpsAssistant.Seedwork.EventSourcing.Persistence
    {
        public class EventStore : IStoreProvider
        {
            private readonly IVersionService versionService;
            private readonly IEventPublisher publisher;
            private readonly CloudTable table;
            private readonly IAggregateEntityFactory aggregateEntityFactory;
            private readonly ICommandEntityFactory commandEntityFactory;
            private readonly IEventEntityFactory eventEntityFactory;

            private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
            { ContractResolver = new PrivateSetterContractResolver() };

            public EventStore(
              IConfiguration configuration,
              IDictionary<string, CloudTable> tables,
              IEventPublisher publisher,
              IVersionService versionService,
              IEventEntityFactory eventEntityFactory,
              ICommandEntityFactory commandEntityFactory,
              IAggregateEntityFactory aggregateEntityFactory)
            {
                var evOptions = configuration.Get<AzureTablesEventSourcingOptions>() ?? throw new ArgumentNullException("configuration.Get<AzureTablesEventSourcingOptions>()");
                table = tables[evOptions.TableName];
                this.publisher = publisher ?? throw new ArgumentNullException("publisher");
                this.versionService = versionService ?? throw new ArgumentNullException("versionService");
                this.eventEntityFactory = eventEntityFactory ?? throw new ArgumentNullException("eventEntityFactory");
                this.commandEntityFactory = commandEntityFactory ?? throw new ArgumentNullException("commandEntityFactory");
                this.aggregateEntityFactory = aggregateEntityFactory ?? throw new ArgumentNullException("aggregateEntityFactory");
            }

            public void Save(SaveStoreData request)
            {
                throw new NotImplementedException();
            }

            public async Task SaveAsync(SaveStoreData request)
            {
                var partitionKey = request.AggregateRootId.ToString();
                var partition = new Partition(table, partitionKey);

                var existent = await Stream.TryOpenAsync(partition);
                var stream = existent.Found
                  ? existent.Stream
                  : new Stream(partition);

                foreach (var @event in request.Events)
                {
                    var currentVersion = stream.Version;
                    //await dbContext.Events.CountAsync(x => x.AggregateId == @event.AggregateRootId);
                    var nextVersion = versionService.GetNextVersion(@event.AggregateRootId,
                                                                    currentVersion,
                                                                    request.DomainCommand?.ExpectedVersion);
                    var newEventEntity = eventEntityFactory.CreateEvent(@event, nextVersion);

                    try
                    {
                        await Stream.WriteAsync(
                          stream,
                          ToEventData(newEventEntity)
                        );
                    }
                    catch (ConcurrencyConflictException e)
                    {
                        throw new ConcurrencyException($"PartitionKey: [{partitionKey}] - {e.Message}", e);
                    }
                }

                //    if (stream.Version != 1)
                //{
                //    throw new ConcurrencyException(
                //        $"Stream Partition version [{stream.Version}]" +
                //        $" not equals event version [{1}] PartitionKey: [{ request.AggregateRootId}]");
                //}

                /*   var tasks = new List<Task>(request.Events.Count());
                   foreach (var @event in request.Events)
                   {
                       // publish current event to the bus for further processing by subscribers
                       tasks.Add(_publisher.Publish(@event));
                   }*/

                // await Task.WhenAll(tasks);
            }

            public IEnumerable<IDomainEvent> GetEvents(Guid aggregateId)
            {
                throw new NotImplementedException();
            }

            public async Task<IEnumerable<IDomainEvent>> GetEventsAsync(Guid aggregateId)
            {
                var result = new List<DomainEvent>();

                var partitionKey = aggregateId.ToString();
                var partition = new Partition(table, partitionKey);

                if (!await Stream.ExistsAsync(partition))
                {
                    throw new AggregateNotFoundException(partitionKey);
                }

                var stream = await Stream.ReadAsync<EventEntity>(partition);
                var events = stream.Events.Select(ToEvent<DomainEvent>).ToList();

                return events;
            }

            private static IDomainEvent ToEvent<TAggregateId>(EventEntity e)
              where TAggregateId : IDomainEvent
            {
                return (IDomainEvent)JsonConvert.DeserializeObject(
                  e.Data,
                  Type.GetType(e.Type),
                  JsonSerializerSettings);
            }

            private static EventData ToEventData(EventEntity e)
            {
                var properties = new
                {
                    Type = e.GetType().AssemblyQualifiedName,
                    Data = JsonConvert.SerializeObject(e)
                };

                return new EventData(EventId.None, EventProperties.From(properties));
            }

            [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
            private class EventEntityT : TableEntity
            {
                public string Type { get; set; }
                public string Data { get; set; }
            }
        }
    }
}
