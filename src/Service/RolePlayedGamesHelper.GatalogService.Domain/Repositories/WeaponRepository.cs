using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class WeaponRepository : RavenDbRepository<  Weapon, int>, IWeaponRepository {
      /// <inheritdoc />
      public WeaponRepository(IDocumentSession session, ICachingStrategy<Weapon, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}