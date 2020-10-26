﻿using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Domain
{
    public interface IDomainCommand : ICommand
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        int? ExpectedVersion { get; set; }
        bool? SaveCommandData { get; set; }
    }

    public interface IDomainCommand<out TAggregateRoot> : IDomainCommand 
        where TAggregateRoot : IAggregateRoot
    {
    }
}
