using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Entities.Factories
{
    public interface IEventEntityFactory
    {
        EventEntity CreateEvent(IDomainEvent @event, int version);
    }
}