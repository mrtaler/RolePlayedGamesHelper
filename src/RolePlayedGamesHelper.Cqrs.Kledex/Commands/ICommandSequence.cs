using System.Collections.ObjectModel;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public interface ICommandSequence
    {
        ReadOnlyCollection<ICommand> Commands { get; }
    }
}
