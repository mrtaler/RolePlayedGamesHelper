using System.Threading.Tasks;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public interface ISequenceCommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task<CommandResponse> HandleAsync(TCommand command, CommandResponse previousStepResponse);
    }
}
