using Microsoft.EntityFrameworkCore;
using RolePlayedGamesHelper.Repository.EntityFrameworkCore.SharpRepository;

namespace RolePlayedGamesHelper.Repository.EntityFrameworkCore
{
    public abstract class DbCoreContextBase : DbContext, ICoreDbContext
    {
    }
}