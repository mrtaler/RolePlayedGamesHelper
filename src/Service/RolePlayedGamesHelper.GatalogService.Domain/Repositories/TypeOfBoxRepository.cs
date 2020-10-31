using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class TypeOfBoxRepository : RavenDbRepository<  TypeOfBox, int> , ITypeOfBoxRepository {
      /// <inheritdoc />
      public TypeOfBoxRepository(IDocumentSession session, ICachingStrategy<TypeOfBox, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}