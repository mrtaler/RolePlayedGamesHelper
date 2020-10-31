using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class CaliberRepository : RavenDbRepository<  Caliber, int> , ICaliberRepository {
      /// <inheritdoc />
      public CaliberRepository(IDocumentSession session, ICachingStrategy<Caliber, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}