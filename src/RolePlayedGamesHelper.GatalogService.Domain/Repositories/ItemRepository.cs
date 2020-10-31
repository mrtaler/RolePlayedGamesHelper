using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class ItemRepository : RavenDbRepository<  Item, int> , IItemRepository {
      /// <inheritdoc />
      public ItemRepository(IDocumentSession session, ICachingStrategy<Item, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}