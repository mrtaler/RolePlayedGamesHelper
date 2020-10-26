using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RolePlayedGamesHelper.Cqrs.Kledex.Extensions;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IKledexAppBuilder EnsureDomainDbCreated(this IKledexAppBuilder builder)
        {
            using (var serviceScope = builder.App.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<DomainDbContext>();
                dbContext.Database.Migrate();
            }

            return builder;
        }
    }
}
