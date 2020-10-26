using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class ItemQuantityChanged : DomainEvent
  {
    public Int32 ItemId { get; set; }
    public Int32 Quantity { get; set; }
  }
}