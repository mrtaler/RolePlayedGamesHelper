using Microsoft.Extensions.Caching.Memory;
using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public class InMemoryCachingProviderConfiguration : CachingProviderConfiguration
    {
        public IMemoryCache Cache { get; set; }

        public InMemoryCachingProviderConfiguration(string name)
        {
            Name = name;
            Factory = typeof (InMemoryConfigCachingProviderFactory);
        }

        public InMemoryCachingProviderConfiguration(string name, IMemoryCache cache)
        {
            Name = name;
            Cache = cache;
            Factory = typeof(InMemoryConfigCachingProviderFactory);
        }

        public override ICachingProvider GetInstance()
        {
            // load up the factory if it exists and use it
            var factory = Cache != null ? 
                new InMemoryConfigCachingProviderFactory(this, Cache) : 
                new InMemoryConfigCachingProviderFactory(this);

            return factory.GetInstance();
        }
    }
}
