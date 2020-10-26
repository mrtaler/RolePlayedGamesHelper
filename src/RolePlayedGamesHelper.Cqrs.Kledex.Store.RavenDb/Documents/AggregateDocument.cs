namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb.Documents
{
    public class AggregateDocument
    {
        //  [BsonId]
        //  [BsonElement("_id")]
        public string Id { get; set; }

        //   [BsonElement("type")]
        public string Type { get; set; }
    }
}