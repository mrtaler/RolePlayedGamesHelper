﻿using Newtonsoft.Json;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities.Factories
{
    public class EventEntityFactory : IEventEntityFactory
    {
        public EventEntity CreateEvent(IDomainEvent @event, int version)
        {
            return new EventEntity
            {
                Id = @event.Id,
                AggregateId = @event.AggregateRootId,
                CommandId = @event.CommandId,
                Sequence = version,
                Type = @event.GetType().AssemblyQualifiedName,
                Data = JsonConvert.SerializeObject(@event),
                TimeStamp = @event.TimeStamp,
                UserId = @event.UserId,
                Source = @event.Source
            };
        }
    }
}