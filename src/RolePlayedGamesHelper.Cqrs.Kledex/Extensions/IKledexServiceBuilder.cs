using Microsoft.Extensions.DependencyInjection;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Extensions
{
    public interface IKledexServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
