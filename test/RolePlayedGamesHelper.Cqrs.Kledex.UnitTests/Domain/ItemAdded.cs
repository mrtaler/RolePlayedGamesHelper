using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class ItemAdded : DomainEvent
  {
    public String Description { get; set; }
    public Int32 Quantity { get; set; }
    public Double Price { get; set; }
    public Boolean Taxable { get; set; }
  }
}