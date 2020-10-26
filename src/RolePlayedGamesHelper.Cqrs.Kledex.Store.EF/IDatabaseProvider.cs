namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF
{
    public interface IDatabaseProvider
    {
        DomainDbContext CreateDbContext(string connectionString);
    }
}