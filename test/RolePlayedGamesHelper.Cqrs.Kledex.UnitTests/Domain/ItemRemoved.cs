using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class ItemRemoved : DomainEvent
  {
    public Int32 ItemId { get; set; }
  }
}