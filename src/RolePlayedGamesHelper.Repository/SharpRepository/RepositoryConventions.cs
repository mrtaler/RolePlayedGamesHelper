using System;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.SharpRepository
{
    public class RepositoryConventions : IRepositoryConventions
    {
        public Func<Type, string> GetPrimaryKeyName { get; set; } 

        public RepositoryConventions()
        {
            GetPrimaryKeyName = DefaultRepositoryConventions.GetPrimaryKeyName;
        }
    }
}
