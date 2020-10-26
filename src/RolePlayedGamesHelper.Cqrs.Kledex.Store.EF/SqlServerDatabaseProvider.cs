using Microsoft.EntityFrameworkCore;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF
{
    public class SqlServerDatabaseProvider : IDatabaseProvider
    {
        public DomainDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DomainDbContext(optionsBuilder.Options);
        }
    }
}