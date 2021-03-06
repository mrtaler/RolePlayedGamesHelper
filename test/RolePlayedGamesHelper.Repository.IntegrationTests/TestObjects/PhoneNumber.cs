﻿using MongoDB.Bson.Serialization.Attributes;
using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects
{
    [BsonIgnoreExtraElements]
    [RepositoryLogging]
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public int ContactId { get; set; }
        public string Label { get; set; }
        public string Number { get; set; }
    }
}