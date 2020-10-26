using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RolePlayedGamesHelper.Cqrs.Kledex.Extensions;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IKledexServiceBuilder AddEFProvider(this IKledexServiceBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.Scan(s => s
                                       .FromAssembliesOf(typeof(DomainDbContext))
                                       .AddClasses()
                                       .AsImplementedInterfaces());

            return builder;
        }

        public static IKledexServiceBuilder AddInMemoryProvider(this IKledexServiceBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.AddEFProvider();

            builder.Services.AddDbContext<DomainDbContext>(options =>
                                                               options.UseInMemoryDatabase(databaseName: "DomainDb"));

            builder.Services.AddTransient<IDatabaseProvider, InMemoryDatabaseProvider>();

            return builder;
        }

        public static IKledexServiceBuilder AddSqlServerProvider(this IKledexServiceBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            builder.AddEFProvider();

            var connectionString = configuration.GetConnectionString(Consts.DomainStoreConnectionString);

            builder.Services.AddDbContext<DomainDbContext>(options =>
                                                               options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IDatabaseProvider, SqlServerDatabaseProvider>();

            return builder;
        }
    }
}