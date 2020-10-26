using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes
{
  public class Aggregate : AggregateRoot
  {
    public Aggregate()
    {
      AddAndApplyEvent(new AggregateCreated());
    }

    private void Apply(AggregateCreated @event)
    {
    }
  }
}
