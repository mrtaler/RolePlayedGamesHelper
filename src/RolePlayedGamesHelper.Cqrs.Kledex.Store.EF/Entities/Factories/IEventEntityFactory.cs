using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities.Factories
{
    public interface IEventEntityFactory
    {
        EventEntity CreateEvent(IDomainEvent @event, int version);
    }
}