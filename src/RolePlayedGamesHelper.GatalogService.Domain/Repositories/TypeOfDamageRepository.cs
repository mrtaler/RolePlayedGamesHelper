﻿using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.RavenDb.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories
{
    public class TypeOfDamageRepository : RavenDbRepository<  TypeOfDamage, int>, ITypeOfDamageRepository {
      /// <inheritdoc />
      public TypeOfDamageRepository(IDocumentSession session, ICachingStrategy<TypeOfDamage, int> cachingStrategy = null) : base(session, cachingStrategy)
      {
      }
    }
}