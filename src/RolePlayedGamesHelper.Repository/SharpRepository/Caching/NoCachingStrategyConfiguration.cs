using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public class NoCachingStrategyConfiguration : CachingStrategyConfiguration
    {
        public NoCachingStrategyConfiguration(string name)
        {
            Name = name;
            Factory = typeof (NoCachingConfigCachingStrategyFactory);
        }
    }
}
