using System;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;

namespace RolePlayedGamesHelper.Cqrs.Kledex
{
    /// <inheritdoc />
    /// <summary>
    /// Dispatcher
    /// </summary>
    /// <seealso cref="T:RolePlayedGamesHelper.Cqrs.Kledex.IDispatcher" />
    public partial class Dispatcher : IDispatcher
    {
        /// <inheritdoc />
        public void Send<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            commandSender.Send(command);
        }

        /// <inheritdoc />
        public void Send<TCommand>(TCommand command, Func<CommandResponse> commandHandler)
            where TCommand : ICommand
        {
            commandSender.Send(command, commandHandler);
        }

        /// <inheritdoc />
        public void Send(ICommandSequence commandSequence)
        {
            commandSender.Send(commandSequence);
        }

        /// <inheritdoc />
        public TResult Send<TResult>(ICommand command)
        {
            return commandSender.Send<TResult>(command);
        }

        /// <inheritdoc />
        public TResult Send<TResult>(ICommand command, Func<CommandResponse> commandHandler)
        {
            return commandSender.Send<TResult>(command, commandHandler);
        }

        /// <inheritdoc />
        public TResult Send<TResult>(ICommandSequence commandSequence)
        {
            return commandSender.Send<TResult>(commandSequence);
        }

        /// <inheritdoc />
        public void Publish<TEvent>(TEvent @event) 
            where TEvent : IEvent
        {
            eventPublisher.Publish(@event);
        }
    }
}