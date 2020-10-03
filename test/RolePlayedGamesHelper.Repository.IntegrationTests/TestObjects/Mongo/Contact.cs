using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using RolePlayedGamesHelper.Repository.MongoDb;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Mongo
{
    [BsonIgnoreExtraElements]
    public class ContactMongo : MongoDbEntity
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int ContactTypeId { get; set; } // for partitioning on 
        public List<EmailAddressMongo> EmailAddresses { get; set; }
        public List<PhoneNumberMongo> PhoneNumbers { get; set; }
        public ContactTypeMongo ContactType { get; set; }
        public byte[] Image { get; set; }
    }





}