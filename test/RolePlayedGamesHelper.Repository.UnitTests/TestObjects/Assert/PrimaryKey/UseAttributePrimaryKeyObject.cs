using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.UnitTests.TestObjects.Assert.PrimaryKey
{
    internal class UseAttributePrimaryKeyObject
    {
        public UseAttributePrimaryKeyObject()
        {

        }
        [RepositoryPrimaryKey]
        public int SomeRandomName { get; set; }
        public string Value { get; set; }
    }
}