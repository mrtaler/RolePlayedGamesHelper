using System;

namespace RolePlayedGamesHelper.Repository
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
