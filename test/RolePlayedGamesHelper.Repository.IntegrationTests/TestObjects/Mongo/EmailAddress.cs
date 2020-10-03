using RolePlayedGamesHelper.Repository.MongoDb;
using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Mongo
{
    
    [RepositoryLogging]
    public class EmailAddressMongo : MongoDbEntity
    {
        public int EmailAddressId { get; set; }
        public int ContactId { get; set; }
        public string Label { get; set; }
        public string Email { get; set; }
    }
}