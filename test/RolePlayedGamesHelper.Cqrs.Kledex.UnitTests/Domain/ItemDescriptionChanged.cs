using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class ItemDescriptionChanged : DomainEvent
  {
    public Int32 ItemId { get; set; }
    public String Description { get; set; }
  }
}