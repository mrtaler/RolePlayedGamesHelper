using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using Options = RolePlayedGamesHelper.Cqrs.Kledex.Configuration.Options;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb.Documents.Factories
{
    public class CommandDocumentFactory : ICommandDocumentFactory
    {
        private readonly Options options;

        private bool SaveCommandData(IDomainCommand command) => command.SaveCommandData ?? options.SaveCommandData;

        public CommandDocumentFactory(IOptions<Options> options)
        {
            this.options = options.Value;
        }

        public CommandDocument CreateCommand(IDomainCommand command)
        {
            return new CommandDocument
            {
                Id = command.Id.ToString(),
                AggregateId = command.AggregateRootId.ToString(),
                Type = command.GetType().AssemblyQualifiedName,
                Data = SaveCommandData(command) ? JsonConvert.SerializeObject(command) : null,
                TimeStamp = command.TimeStamp,
                UserId = command.UserId,
                Source = command.Source
            };
        }
    }
}