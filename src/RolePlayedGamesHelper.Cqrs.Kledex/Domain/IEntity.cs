using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
