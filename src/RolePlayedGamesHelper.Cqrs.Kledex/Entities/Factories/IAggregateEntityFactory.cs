using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Entities.Factories
{
    public interface IAggregateEntityFactory
    {
        AggregateEntity CreateAggregate(Type aggregateType, Guid aggregateRootId);
    }
}