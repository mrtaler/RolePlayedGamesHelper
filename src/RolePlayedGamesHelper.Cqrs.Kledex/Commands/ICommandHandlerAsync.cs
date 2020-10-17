using System.Threading.Tasks;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task<CommandResponse> HandleAsync(TCommand command);
    }
}
