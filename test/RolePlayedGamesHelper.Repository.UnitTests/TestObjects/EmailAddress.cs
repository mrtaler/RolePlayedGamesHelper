﻿using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.UnitTests.TestObjects
{
    [RepositoryLogging]
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public int ContactId { get; set; }
        public string Label { get; set; }
        public string Email { get; set; }
    }
}