using RolePlayedGamesHelper.Cqrs.Kledex.Commands;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes
{
  public class SampleCommandSequence : CommandSequence
  {
    public SampleCommandSequence()
    {
      AddCommand(new CommandInSequence());
    }
  }
}
