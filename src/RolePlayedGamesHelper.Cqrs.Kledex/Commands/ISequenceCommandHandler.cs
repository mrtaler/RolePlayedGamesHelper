﻿namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public interface ISequenceCommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResponse Handle(TCommand command, CommandResponse previousStepResponse);
    }
}
