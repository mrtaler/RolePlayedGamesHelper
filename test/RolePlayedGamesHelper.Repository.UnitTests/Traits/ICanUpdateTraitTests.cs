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
    public class ICanUpdateTraitTests : TestBase
    {
        [Fact]
        public void ICanUpdate_Exposes_Update_Entity()
        {
            var repo = new ContactRepository(
                                                 new ConcurrentDictionary<int, Contact>());

            var contact = new Contact { Name = "Name" };
            repo.Add(contact);

            contact.Name = "New Name";
            repo.Update(contact);
        }

        [Fact]
        public void ICanUpdate_Exposes_Update_Multiple_Entities()
        {
            var repo = new ContactRepository(
                                                 new ConcurrentDictionary<int, Contact>());

            IList<Contact> contacts = new List<Contact>
                                        {
                                            new Contact {Name = "Contact 1"},
                                            new Contact {Name = "Contact 2"},
                                            new Contact {Name = "Contact 3"},
                                        };

            repo.Add(contacts);
            
            foreach (var contact in contacts)
            {
                contact.Name += " New Name";
            }

            repo.Update(contacts);
        }
       
        private class ContactRepository : InMemRepository<Contact, int>, IContactRepository
        {
            /// <inheritdoc />
            public ContactRepository(
                ConcurrentDictionary<int, Contact> dataContextFactory,
                ICachingStrategy<Contact, int>     cachingStrategy = null)
                : base(dataContextFactory, cachingStrategy)
            {
            }
        }

        private interface IContactRepository : ICanUpdate<Contact>
        {
        }
    }
}