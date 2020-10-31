using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class LaserColorEfRepository : RavenDbRepository<  LaserColorEf,int>, ILaserColorEfRepository {
      /// <inheritdoc />
      public LaserColorEfRepository(IDocumentSession session, ICachingStrategy<LaserColorEf, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}