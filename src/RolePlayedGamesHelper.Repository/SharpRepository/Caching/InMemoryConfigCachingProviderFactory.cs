using System;
using Microsoft.Extensions.Caching.Memory;
using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public class InMemoryConfigCachingProviderFactory : ConfigCachingProviderFactory
    {
        protected IMemoryCache Cache;

        public InMemoryConfigCachingProviderFactory(ICachingProviderConfiguration config)
            : base(config)
        {
            if(RepositoryDependencyResolver.Current == null)
            {
                throw new Exception("RepositoryDependencyResolver.Current must be configured with the instance of IMemoryCache");
            }
            
            Cache = RepositoryDependencyResolver.Current.Resolve<IMemoryCache>();

            if (Cache == null)
            {
                throw new RepositoryDependencyResolverException(typeof(IMemoryCache));
            }
        }

        public InMemoryConfigCachingProviderFactory(ICachingProviderConfiguration config, IMemoryCache memoryCache)
            : base(config) 
        {
            Cache = memoryCache;
        }

        public override ICachingProvider GetInstance()
        {
            return new InMemoryCachingProvider(Cache);
        }
    }
}
