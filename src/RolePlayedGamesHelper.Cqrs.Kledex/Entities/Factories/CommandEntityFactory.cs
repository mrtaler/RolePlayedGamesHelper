using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using Options = RolePlayedGamesHelper.Cqrs.Kledex.Configuration.Options;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Entities.Factories
{
    public class CommandEntityFactory : ICommandEntityFactory
    {
        private readonly Options options;

        private bool SaveCommandData(IDomainCommand command) => command.SaveCommandData ?? options.SaveCommandData;

        public CommandEntityFactory(IOptions<Options> options)
        {
            this.options = options.Value;
        }

        public CommandEntity CreateCommand(IDomainCommand command)
        {
            return new CommandEntity
            {
                Id = command.Id,
                AggregateId = command.AggregateRootId,
                Type = command.GetType().AssemblyQualifiedName,
                Data = SaveCommandData(command) ? JsonConvert.SerializeObject(command) : null,
                TimeStamp = command.TimeStamp,
                UserId = command.UserId,
                Source = command.Source
            };
        }
    }
}