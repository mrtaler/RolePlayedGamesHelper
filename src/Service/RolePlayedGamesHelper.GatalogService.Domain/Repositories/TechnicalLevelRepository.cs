using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class TechnicalLevelRepository : RavenDbRepository<  TechnicalLevel, int> , ITechnicalLevelRepository {
      /// <inheritdoc />
      public TechnicalLevelRepository(IDocumentSession session, ICachingStrategy<TechnicalLevel, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}