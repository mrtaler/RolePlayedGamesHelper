using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
  /// <summary>
  /// The ammo upgrates repository.
  /// </summary>
  public class AmmoUpgratesRepository : RavenDbRepository<AmmoUpgrades, int>, IAmmoUpgradesRepository
  {
    /// <inheritdoc />
    public AmmoUpgratesRepository(
      IDocumentSession session,
      ICachingStrategy<AmmoUpgrades, int> cachingStrategy = null) : base(session, cachingStrategy)
    {
    }
  }
}