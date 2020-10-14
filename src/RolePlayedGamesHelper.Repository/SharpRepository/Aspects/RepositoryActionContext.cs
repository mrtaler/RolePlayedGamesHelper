using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public class RepositoryActionContext<T, TKey> 
        where T : class
    {
        public RepositoryActionContext(IRepository<T, TKey> repository)
        {
            Repository = repository;
        }

        public IRepository<T, TKey> Repository { get; set; }
    }
}