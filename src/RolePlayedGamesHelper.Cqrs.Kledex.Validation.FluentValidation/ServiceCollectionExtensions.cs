using System;
using Microsoft.Extensions.DependencyInjection;
using RolePlayedGamesHelper.Cqrs.Kledex.Extensions;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Validation.FluentValidation
{
    public static class ServiceCollectionExtensions
    {
        public static IKledexServiceBuilder AddFluentValidationProvider(this IKledexServiceBuilder builder)
        {
            builder.Services.AddTransient<IValidationProvider, FluentValidationProvider>();

            return builder;
        }
    }
}