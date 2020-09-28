using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public class NoCachingConfigCachingStrategyFactory : ConfigCachingStrategyFactory
    {
        public NoCachingConfigCachingStrategyFactory(ICachingStrategyConfiguration config)
            : base(config)
        {

        }

        public override ICachingStrategy<T, TKey> GetInstance<T, TKey>(ICachingProvider cachingProvider)
        {
            return new NoCachingStrategy<T, TKey>();
        }

        public override ICompoundKeyCachingStrategy<T, TKey, TKey2> GetInstance<T, TKey, TKey2>(ICachingProvider cachingProvider)
        {
            return new NoCachingStrategy<T, TKey, TKey2>();
        }

        public override ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> GetInstance<T, TKey, TKey2, TKey3>(ICachingProvider cachingProvider)
        {
            return new NoCachingStrategy<T, TKey, TKey2, TKey3>();
        }
        public override ICompoundKeyCachingStrategy<T> GetCompoundKeyInstance<T>(ICachingProvider cachingProvider)
        {
            return new NoCompoundKeyCachingStrategy<T>();
        }
    }
}
