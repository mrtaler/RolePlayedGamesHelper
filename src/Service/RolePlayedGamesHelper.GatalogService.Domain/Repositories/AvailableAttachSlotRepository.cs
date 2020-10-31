using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
  public class AvailableAttachSlotRepository : RavenDbRepository<AvailableAttachSlot, int>, IAvailableAttachSlotRepository
  {
    /// <inheritdoc />
    public AvailableAttachSlotRepository(IDocumentSession session, ICachingStrategy<AvailableAttachSlot, int> cachingStrategy = null) : base(session, cachingStrategy)
    {
    }
  }
}