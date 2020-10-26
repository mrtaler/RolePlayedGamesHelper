using RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb.Documents;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb
{
    public class DomainDbContext
    {
        /// <summary>
        /// The aggregates.
        /// </summary>
        private IRepository<AggregateDocument, string> aggregates;

        /// <summary>
        /// The commands.
        /// </summary>
        private IRepository<CommandDocument, string> commands;

        /// <summary>
        /// The events.
        /// </summary>
        private IRepository<EventDocument, string> events;

        public DomainDbContext(
            IRepository<AggregateDocument, string> aggregates,
            IRepository<CommandDocument, string> commands,
            IRepository<EventDocument, string> events)
        {
            this.aggregates = aggregates;
            this.commands = commands;
            this.events = events;
        }

        public IRepository<AggregateDocument, string> Aggregates => aggregates;

        public IRepository<CommandDocument, string> Commands => commands;

        public IRepository<EventDocument, string> Events => events;
    }
}