using System.Threading.Tasks;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Events
{
    public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
