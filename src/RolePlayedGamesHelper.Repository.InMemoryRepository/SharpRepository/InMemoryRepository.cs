using System.Collections.Concurrent;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository
{
    public class InMemRepository<T, TKey> : InMemoryRepositoryBase<T, TKey> where T : class, new()
    {
        public InMemRepository(
            ConcurrentDictionary<TKey, T> items,
            ICachingStrategy<T, TKey>     cachingStrategy = null)
            : base(items, cachingStrategy)
        {
        }
    }

    // The IRepository<T> is needed here and not on the one above in order to allow programming against IRepository<T> when using an int as the PK
    public class InMemRepository<T> : InMemoryRepositoryBase<T, int>, IRepository<T> where T : class, new()
    {
        public InMemRepository(
            ConcurrentDictionary<int, T> items,
            ICachingStrategy<T, int>      cachingStrategy = null)
            : base(items, cachingStrategy)
        {
        }
    }
}
