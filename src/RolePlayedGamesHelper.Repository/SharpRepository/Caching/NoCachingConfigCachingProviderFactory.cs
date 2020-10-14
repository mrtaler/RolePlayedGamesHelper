using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public class NoCachingConfigCachingProviderFactory : ConfigCachingProviderFactory
    {
        public NoCachingConfigCachingProviderFactory(ICachingProviderConfiguration config)
            : base(config)
        {
        }

        public override ICachingProvider GetInstance()
        {
            return new NoCachingProvider();
        }
    }
}
