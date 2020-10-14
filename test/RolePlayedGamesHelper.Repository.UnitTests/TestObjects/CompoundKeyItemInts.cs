using RolePlayedGamesHelper.Repository.SharpRepository.Attributes;

namespace RolePlayedGamesHelper.Repository.UnitTests.TestObjects
{
    public class CompoundKeyItemInts
    {
        [RepositoryPrimaryKey(Order = 1)]
        public int SomeId { get; set; }

        [RepositoryPrimaryKey(Order = 2)]
        public int AnotherId { get; set; }

        public string Title { get; set; }
    }
}