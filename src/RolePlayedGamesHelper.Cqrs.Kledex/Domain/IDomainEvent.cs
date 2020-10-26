using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Domain
{
    public interface IDomainEvent : IEvent
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        Guid CommandId { get; set; }
        void Update(IDomainCommand command);
    }
}
