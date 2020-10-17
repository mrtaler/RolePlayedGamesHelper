using System.Collections.Concurrent;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;
using Xunit;

namespace RolePlayedGamesHelper.Repository.UnitTests.Caching
{

    public class DisabledCacheTests
    {
       [Fact]
        public void Using_DisableCaching_Should_Disable_Cache_Inside_Using_Block()
        {
            var cacheProvider = new InMemoryCachingProvider(new MemoryCache(new MemoryCacheOptions()));
            var repos = new InMemRepository<Contact>(
                new ConcurrentDictionary<int, Contact>(), new StandardCachingStrategy<Contact>(cacheProvider));

            repos.CachingEnabled.Should().BeTrue();

            using (repos.DisableCaching())
            {
                repos.CachingEnabled.Should().BeFalse();
            }

            repos.CachingEnabled.Should().BeTrue();
        }
    }
}
