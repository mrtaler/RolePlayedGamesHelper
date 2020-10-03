using RolePlayedGamesHelper.Repository.MongoDb;
using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Mongo
{
    
    [RepositoryLogging]
    public class PhoneNumberMongo : MongoDbEntity
    {
        public int PhoneNumberId { get; set; }
        public int ContactId { get; set; }
        public string Label { get; set; }
        public string Number { get; set; }
    }
}