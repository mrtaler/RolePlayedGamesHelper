using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public class RepositoryGetContext<T, TKey> : RepositoryGetContext<T, TKey, T>
        where T : class
    {
        public RepositoryGetContext(IRepository<T, TKey> repository, TKey id) : base(repository, id)
        {
        }
    }
}