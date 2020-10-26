using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Seedwork.Api.ServiceDomain
{
  /// <summary>
  /// The service domain event handler.
  /// </summary>
  public class ServiceDomainEventHandler : IServiceDomainEventHandler
  {
    /// <summary>
    /// The notifications.
    /// </summary>
    private readonly List<ServiceDomainEvent> notifications;

    /// <summary> 
    /// The event store.
    /// </summary>
    private readonly IStoreProvider eventStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceDomainEventHandler"/> class.
    /// </summary>
    /// <param name="eventStore">
    /// The event store.
    /// </param>
    public ServiceDomainEventHandler(IStoreProvider eventStore)
    {
      this.eventStore = eventStore;
      notifications = new List<ServiceDomainEvent>();
    }

    /// <summary>
    /// The handle async.
    /// </summary>
    /// <param name="events">
    /// The events.
    /// </param>
    /// <returns>
    /// The <see cref="Task"/>.
    /// </returns>
    public Task HandleAsync(ServiceDomainEvent events)
    {
      notifications.Add(events);
      eventStore.SaveAsync(new SaveStoreData
      {
        AggregateType = events.GetType(),
        AggregateRootId = events.AggregateRootId,
        Events = new List<IDomainEvent> { events },
        DomainCommand = null
      });
      return Task.CompletedTask;
    }

    /// <summary>
    /// The has notifications.
    /// </summary>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool HasNotifications()
    {
      return GetNotifications().Any();
    }

    /// <summary>
    /// The get notifications.
    /// </summary>
    /// <returns>
    /// The <see>
    ///     <cref>List</cref>
    /// </see>
    /// .
    /// </returns>
    public List<ServiceDomainEvent> GetNotifications()
    {
      return notifications;
    }
  }
}