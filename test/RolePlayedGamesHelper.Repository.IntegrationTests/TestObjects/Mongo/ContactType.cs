using RolePlayedGamesHelper.Repository.MongoDb;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Mongo
{
    
    public class ContactTypeMongo : MongoDbEntity
    {
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}