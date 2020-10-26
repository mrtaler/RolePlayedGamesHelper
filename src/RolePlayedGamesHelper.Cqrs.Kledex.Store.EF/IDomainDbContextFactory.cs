namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF
{
    public interface IDomainDbContextFactory
    {
        DomainDbContext CreateDbContext();
    }
}