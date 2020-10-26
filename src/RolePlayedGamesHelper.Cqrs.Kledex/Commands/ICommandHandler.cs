﻿namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResponse Handle(TCommand command);
    }
}