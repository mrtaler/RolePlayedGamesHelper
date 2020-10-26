﻿using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities.Factories
{
    public interface IAggregateEntityFactory
    {
        AggregateEntity CreateAggregate(Type aggregateType, Guid aggregateRootId);
    }
}