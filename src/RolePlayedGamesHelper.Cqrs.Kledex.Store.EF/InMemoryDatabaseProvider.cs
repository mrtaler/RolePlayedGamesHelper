using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF
{
    public class InMemoryDatabaseProvider : IDatabaseProvider
    {
        public DomainDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainDbContext>();
            optionsBuilder.UseInMemoryDatabase(connectionString);

            return new DomainDbContext(optionsBuilder.Options);
        }
    }
}
