using System;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository
{
    public interface IRepositoryConventions
    {
        Func<Type, string> GetPrimaryKeyName { get; set; } 
    }
}
