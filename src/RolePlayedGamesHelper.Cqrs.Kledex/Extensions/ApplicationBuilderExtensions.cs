using Microsoft.AspNetCore.Builder;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IKledexAppBuilder UseKledex(this IApplicationBuilder app)
        {
            return new KledexAppBuilder(app);
        }
    }
}