using System.Reflection;
using RolePlayedGamesHelper.Repository.EntityFrameworkCore.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.Repository.UnitTests.PrimaryKey
{
    public class TestEfCoreRepository<T, TKey> : EfCoreRepository<T, TKey> where T : class, new()
    {
        public TestEfCoreRepository(ICoreDbContext dbContext, ICachingStrategy<T, TKey> cachingStrategy = null) 
            : base(dbContext, cachingStrategy)
        {
        }

        public PropertyInfo TestGetPrimaryKeyPropertyInfo()
        {
            return GetPrimaryKeyPropertyInfo();
        }
    }
}