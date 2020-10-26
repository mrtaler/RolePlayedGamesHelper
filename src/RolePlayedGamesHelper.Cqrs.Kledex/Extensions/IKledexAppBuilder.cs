using Microsoft.AspNetCore.Builder;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Extensions
{
    public interface IKledexAppBuilder
    {
        IApplicationBuilder App { get; }
    }
}