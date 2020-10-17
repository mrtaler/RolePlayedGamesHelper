using Microsoft.EntityFrameworkCore;
using RolePlayedGamesHelper.Repository.EntityFrameworkCore;

namespace RolePlayedGamesHelper.Repository.UnitTests.TestObjects
{
    public class DataContextFactory : DbCoreContextFactory<TestObjectContextCore>
    {
        public DataContextFactory(DbContextOptions<TestObjectContextCore> options) : base(options)
        {
        }
    }
}