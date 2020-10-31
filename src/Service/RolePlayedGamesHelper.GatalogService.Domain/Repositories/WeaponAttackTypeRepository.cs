using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class WeaponAttackTypeRepository : RavenDbRepository<  WeaponAttackType, int>, IWeaponAttackTypeRepository {
      /// <inheritdoc />
      public WeaponAttackTypeRepository(IDocumentSession session, ICachingStrategy<WeaponAttackType, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}