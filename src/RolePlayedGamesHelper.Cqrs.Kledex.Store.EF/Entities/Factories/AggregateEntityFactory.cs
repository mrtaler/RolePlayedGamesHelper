﻿using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities.Factories
{
    public class AggregateEntityFactory : IAggregateEntityFactory
    {
        public AggregateEntity CreateAggregate(Type aggregateType, Guid aggregateRootId)
        {
            return new AggregateEntity
            {
                Id   = aggregateRootId,
                Type = aggregateType.AssemblyQualifiedName
            };
        }
    }
}