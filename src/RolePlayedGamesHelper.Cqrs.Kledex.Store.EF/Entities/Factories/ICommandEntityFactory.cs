using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities.Factories
{
    public interface ICommandEntityFactory
    {
        CommandEntity CreateCommand(IDomainCommand command);
    }
}