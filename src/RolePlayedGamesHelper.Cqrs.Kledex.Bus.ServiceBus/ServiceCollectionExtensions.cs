using System;
using Microsoft.Extensions.DependencyInjection;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus.ServiceBus.Factories;
using RolePlayedGamesHelper.Cqrs.Kledex.Extensions;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Bus.ServiceBus
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the service bus provider.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IKledexServiceBuilder AddServiceBusProvider(this IKledexServiceBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services
                   .AddTransient<IBusMessageDispatcher, BusMessageDispatcher>()
                   .AddTransient<IBusProvider, BusProvider>()
                   .AddTransient<IMessageFactory, MessageFactory>();

            return builder;
        }
    }
}
