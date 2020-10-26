using System;
using Microsoft.Extensions.Configuration;
using RolePlayedGamesHelper.Cqrs.Kledex.Dependencies;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF
{
    public class DomainDbContextFactory : IDomainDbContextFactory
    {
        private readonly IResolver resolver;
        private readonly string connectionString;

        public DomainDbContextFactory(IResolver resolver, IConfiguration configuration)
        {
            this.resolver = resolver;
            connectionString = configuration.GetConnectionString(Consts.DomainStoreConnectionString);
        }

        public DomainDbContext CreateDbContext()
        {
            var dataProvider = resolver.Resolve<IDatabaseProvider>();

            if (dataProvider == null)
                throw new ApplicationException("Domain database provider not found.");

            return dataProvider.CreateDbContext(connectionString);
        }
    }
}