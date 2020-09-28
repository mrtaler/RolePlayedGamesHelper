using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public class TimeoutCachingStrategyConfiguration : CachingStrategyConfiguration
    {
        public TimeoutCachingStrategyConfiguration(string name, int timeoutInSeconds)
            : this(name, timeoutInSeconds, null)
        {
        }

        public TimeoutCachingStrategyConfiguration(string name, int timeoutInSeconds, int? maxResults)
        {
            Name = name;
            Timeout = timeoutInSeconds;
            MaxResults = maxResults;
            Factory = typeof(TimeoutConfigCachingStrategyFactory);
        }

        public int Timeout
        {
            set { Attributes["timeout"] = value.ToString(); }
        }
    }
}
