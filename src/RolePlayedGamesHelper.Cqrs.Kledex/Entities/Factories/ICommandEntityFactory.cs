using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Entities.Factories
{
    public interface ICommandEntityFactory
    {
        CommandEntity CreateCommand(IDomainCommand command);
    }
}