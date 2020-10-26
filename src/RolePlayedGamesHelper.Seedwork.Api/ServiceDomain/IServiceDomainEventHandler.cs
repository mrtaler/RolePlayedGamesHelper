using System.Collections.Generic;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;

namespace RolePlayedGamesHelper.Seedwork.Api.ServiceDomain
{
  /// <summary>
  /// The ServiceDomainEventHandler interface.
  /// </summary>
  public interface IServiceDomainEventHandler : IEventHandlerAsync<ServiceDomainEvent>
  {
    /// <summary>
    /// The has notifications.
    /// </summary>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    bool HasNotifications();

    /// <summary>
    /// The get notifications.
    /// </summary>
    /// <returns>
    /// The <see cref="T:List"/>.
    /// </returns>
    List<ServiceDomainEvent> GetNotifications();
  }
}