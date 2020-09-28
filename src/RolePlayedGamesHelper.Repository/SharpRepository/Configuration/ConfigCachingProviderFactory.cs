using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Configuration
{
    public interface IConfigCachingProviderFactory
    {
        ICachingProvider GetInstance();
    }

    public abstract class ConfigCachingProviderFactory : IConfigCachingProviderFactory
    {
        protected ICachingProviderConfiguration CachingProviderConfiguration;

        protected ConfigCachingProviderFactory(ICachingProviderConfiguration config)
        {
            CachingProviderConfiguration = config;
        }

        public abstract ICachingProvider GetInstance();
    }
}
