using System.Collections.Concurrent;
using System.Collections.Generic;
using RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.Traits;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects.Assert;
using Xunit;

namespace RolePlayedGamesHelper.Repository.UnitTests.Traits
{
 
    public class ICanAddTraitTests : TestBase
    {
        [Fact]
        public void ICanAdd_Exposes_Add_Entity()
        {
            var repo = new ContactRepository(
                                                 new ConcurrentDictionary<int, Contact>());
            repo.Add(new Contact());
        }

        [Fact]
        public void ICanAdd_Exposes_Add_Multiple_Entities()
        {
            var repo = new ContactRepository(
                                                 new ConcurrentDictionary<int, Contact>());
            repo.Add(new List<Contact> { new Contact(), new Contact() });
        }

        private class ContactRepository : InMemRepository<Contact, int>, IContactRepository
        {
            /// <inheritdoc />
            public ContactRepository(
                ConcurrentDictionary<int, Contact> dataContextFactory,
                ICachingStrategy<Contact, int>                cachingStrategy = null) 
                : base(dataContextFactory, cachingStrategy)
            {
            }
        }

        private interface IContactRepository : ICanAdd<Contact>
        {
        }
    }
}