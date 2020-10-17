using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;

namespace RolePlayedGamesHelper.Repository.UnitTests.PrimaryKey
{
    internal class TestRepository<T, TKey> : InMemRepository<T, TKey> where T : class, new()
    {
        public PropertyInfo TestGetPrimaryKeyPropertyInfo()
        {
            return GetPrimaryKeyPropertyInfo();
        }

        public void SuppressAudit()
        {
            DisableAspect(typeof(AuditAttributeMock));
        }

        public void RestoreAudit()
        {
            EnableAspect(typeof(AuditAttributeMock));
        }

        public IEnumerable<RepositoryActionBaseAttribute> GetAspects()
        {
            return Aspects;
        }

        /// <inheritdoc />
        public TestRepository(ConcurrentDictionary<TKey, T> items, ICachingStrategy<T, TKey> cachingStrategy = null)
            : base(items, cachingStrategy)
        {
        }
    }
}