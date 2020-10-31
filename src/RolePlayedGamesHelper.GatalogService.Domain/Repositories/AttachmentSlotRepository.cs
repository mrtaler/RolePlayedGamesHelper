using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class AttachmentSlotRepository : RavenDbRepository<  AttachmentSlot, int>, IAttachmentSlotRepository {
      /// <inheritdoc />
      public AttachmentSlotRepository(IDocumentSession session, ICachingStrategy<AttachmentSlot, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}