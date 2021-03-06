﻿using System.Collections.Concurrent;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;
using Xunit;

namespace RolePlayedGamesHelper.Repository.UnitTests.Caching
{
    public class ClearCacheTests
    {
        private ICachingProvider cacheProvider;

        public ClearCacheTests()
        {
            cacheProvider = new InMemoryCachingProvider(new MemoryCache(new MemoryCacheOptions()));
        }

        [Fact]
        public void ClearAllCache_Throws_Exception_WIthout_OutOfBox()
        {
            try
            {
                Cache.ClearAll();
                Assert.True(false, "No exception was thrown when it should have been");
            }
            catch
            {
            }
        }

        [Fact]
        public void ClearAllCache_Changes_FullCachePrefix_When_Configured()
        {
            Cache.CachePrefixManager = new SingleServerCachePrefixManager();

            var repos = new InMemRepository<Contact>(
                    new ConcurrentDictionary<int, Contact>(), new StandardCachingStrategy<Contact>(cacheProvider));

            var fullCachePrefix = repos.CachingStrategy.FullCachePrefix;

            // shouldn't change if we call it again
            repos.CachingStrategy.FullCachePrefix.Should().Be(fullCachePrefix);

            // clear out all cached items across all repositories
            Cache.ClearAll();

            // this should have changed this time
            repos.CachingStrategy.FullCachePrefix.Should().NotBe(fullCachePrefix);
        }

        [Fact]
        public void ClearCache_Changes_FullCachePrefix()
        {
            var repos = new InMemRepository<Contact>(
                    new ConcurrentDictionary<int, Contact>(), new StandardCachingStrategy<Contact>(cacheProvider));

            var fullCachePrefix = repos.CachingStrategy.FullCachePrefix;

            // shouldn't change if we call it again
            repos.CachingStrategy.FullCachePrefix.Should().Be(fullCachePrefix);

            // clear out only the cache for this specific repository
            repos.ClearCache();

            // this should have changed this time
            repos.CachingStrategy.FullCachePrefix.Should().NotBe(fullCachePrefix);
        }
    }
}
