using System;
using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
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
        private readonly ICommandSender commandSender;
        private readonly IEventPublisher eventPublisher;
        private readonly IBusMessageDispatcher busMessageDispatcher;

        public Dispatcher(ICommandSender domainCommandSender,
            IEventPublisher eventPublisher,
            IBusMessageDispatcher busMessageDispatcher)
        {
            commandSender             = domainCommandSender;
            this.eventPublisher       = eventPublisher;
            this.busMessageDispatcher = busMessageDispatcher;
        }

        /// <inheritdoc />
        public Task SendAsync<TCommand>(TCommand command) 
            where TCommand : ICommand
        {
            return commandSender.SendAsync(command);
        }

        /// <inheritdoc />
        public Task SendAsync<TCommand>(TCommand command, Func<Task<CommandResponse>> commandHandler) 
            where TCommand : ICommand
        {
            return commandSender.SendAsync(command, commandHandler);
        }

        /// <inheritdoc />
        public Task SendAsync(ICommandSequence commandSequence)
        {
            return commandSender.SendAsync(commandSequence);
        }

        /// <inheritdoc />
        public Task<TResult> SendAsync<TResult>(ICommand command)
        {
            return commandSender.SendAsync<TResult>(command);
        }

        /// <inheritdoc />
        public Task<TResult> SendAsync<TResult>(ICommand command, Func<Task<CommandResponse>> commandHandler)
        {
            return commandSender.SendAsync<TResult>(command, commandHandler);
        }

        /// <inheritdoc />
        public Task<TResult> SendAsync<TResult>(ICommandSequence commandSequence)
        {
            return commandSender.SendAsync<TResult>(commandSequence);
        }

        /// <inheritdoc />
        public Task PublishAsync<TEvent>(TEvent @event) 
            where TEvent : IEvent
        {
            return eventPublisher.PublishAsync(@event);
        }

        /// <inheritdoc />
        public Task DispatchBusMessageAsync<TMessage>(TMessage message) 
            where TMessage : IBusMessage
        {
            return busMessageDispatcher.DispatchAsync(message);
        }
    }
}