using Microsoft.EntityFrameworkCore;

namespace RolePlayedGamesHelper.Repository.EntityFrameworkCore
{
    public abstract class DbCoreContextBase : DbContext, ICoreDbContext
    {
    }
}