using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;
using RolePlayedGamesHelper.Cqrs.Kledex.Queries;

namespace RolePlayedGamesHelper.Cqrs.Kledex
{
    /// <inheritdoc />
    /// <summary>
    /// Dispatcher
    /// </summary>
    /// <seealso cref="T:RolePlayedGamesHelper.Cqrs.Kledex.IDispatcher" />
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandSender commandSender;
        private readonly IEventPublisher eventPublisher;
        private readonly IQueryProcessor queryProcessor;
        private readonly IBusMessageDispatcher busMessageDispatcher;

        public Dispatcher(ICommandSender domainCommandSender,
            IEventPublisher eventPublisher,
            IQueryProcessor queryProcessor,
            IBusMessageDispatcher busMessageDispatcher)
        {
            commandSender = domainCommandSender;
            this.eventPublisher = eventPublisher;
            this.queryProcessor = queryProcessor;
            this.busMessageDispatcher = busMessageDispatcher;
        }

        /// <inheritdoc />
        public Task SendAsync(ICommand command)
        {
            return commandSender.SendAsync(command);
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
        public Task<TResult> GetResultAsync<TResult>(IQuery<TResult> query)
        {
            return queryProcessor.ProcessAsync(query);
        }

        /// <inheritdoc />
        public Task DispatchBusMessageAsync<TMessage>(TMessage message)
            where TMessage : IBusMessage
        {
            return busMessageDispatcher.DispatchAsync(message);
        }

        /// <inheritdoc />
        public void Send(ICommand command)
        {
            commandSender.Send(command);
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

        /// <inheritdoc />
        public TResult GetResult<TResult>(IQuery<TResult> query)
        {
            return queryProcessor.Process(query);
        }
    }
}