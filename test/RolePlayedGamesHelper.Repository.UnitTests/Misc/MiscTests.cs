﻿using System.Collections.Concurrent;
using FluentAssertions;
using RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;
using Xunit;

namespace RolePlayedGamesHelper.Repository.UnitTests.Misc
{
    public class MiscTests
    {
        [Fact]
        public void EntityType_Returns_Proper_Type()
        {
            var repo = new InMemRepository<Contact>(
                    new ConcurrentDictionary<int, Contact>());
            repo.EntityType.Should().Be(typeof(Contact));
        }

        [Fact]
        public void KeyType_Returns_Proper_Type()
        {
            var repo = new InMemRepository<Contact, int>(
                    new ConcurrentDictionary<int, Contact>());
            repo.KeyType.Should().Be(typeof(int));
        }

        [Fact]
        public void KeyType_Implied_Returns_Proper_Type()
        {
            var repo = new InMemRepository<Contact>(
                    new ConcurrentDictionary<int, Contact>());
            repo.KeyType.Should().Be(typeof(int));
        }
    }
}
