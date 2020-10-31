using System;
using Microsoft.Extensions.DependencyInjection;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using RolePlayedGamesHelper.Cqrs.Kledex.Extensions;
using RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb.Documents.Factories;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb
{
    public static class ServiceCollectionExtensions
    {
        public static IKledexServiceBuilder AddRavenDbdataProvider(this IKledexServiceBuilder builder)
        {
            return AddRavenDbDataProvider(builder, opt => { });
        }

        public static IKledexServiceBuilder AddRavenDbDataProvider(
            this IKledexServiceBuilder builder,
            Action<DomainDbOptions> setupAction)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            builder.Services.Configure(setupAction);

            builder.Services
                .AddTransient<IStoreProvider, StoreProvider>();

            builder.Services
                .AddTransient<IAggregateDocumentFactory, AggregateDocumentFactory>()
                .AddTransient<ICommandDocumentFactory, CommandDocumentFactory>()
                .AddTransient<IEventDocumentFactory, EventDocumentFactory>();


           /* builder.Services
                   .AddTransient<IRepository<AggregateDocument, string>, EfCoreRepository<AggregateDocument, string>>();
            builder.Services
                   .AddTransient<IRepository<CommandDocument, string>, EfCoreRepository<CommandDocument, string>>();
            builder.Services
                   .AddTransient<IRepository<EventDocument, string>, EfCoreRepository<EventDocument, string>>();
*/



            return builder;
        }
    }
}
