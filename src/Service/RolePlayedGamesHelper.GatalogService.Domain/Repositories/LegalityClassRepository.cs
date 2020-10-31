using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class LegalityClassRepository : RavenDbRepository<  LegalityClass,int> , ILegalityClassRepository {
      /// <inheritdoc />
      public LegalityClassRepository(IDocumentSession session, ICachingStrategy<LegalityClass, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}