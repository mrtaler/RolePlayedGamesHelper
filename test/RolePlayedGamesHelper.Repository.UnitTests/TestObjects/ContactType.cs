using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.UnitTests.TestObjects
{
    [RepositoryLogging]
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}