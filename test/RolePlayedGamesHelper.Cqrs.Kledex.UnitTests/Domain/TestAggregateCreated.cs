using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class TestAggregateCreated : DomainEvent
  {
    public Int32 Number { get; set; }

    public TestAggregateCreated(Int32 number) => Number = number;
  }
}