using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class GurpsClassRepository : RavenDbRepository<  GurpsClass, int>, IGurpsClassRepository {
      /// <inheritdoc />
      public GurpsClassRepository(IDocumentSession session, ICachingStrategy<GurpsClass, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}