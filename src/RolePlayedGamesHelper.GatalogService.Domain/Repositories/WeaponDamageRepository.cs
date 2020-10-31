using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class WeaponDamageRepository : RavenDbRepository<  WeaponDamage, int>, IWeaponDamageRepository {
      /// <inheritdoc />
      public WeaponDamageRepository(IDocumentSession session, ICachingStrategy<WeaponDamage, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}