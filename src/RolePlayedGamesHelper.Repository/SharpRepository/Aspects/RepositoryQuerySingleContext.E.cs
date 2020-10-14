using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.SharpRepository.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.Specifications;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public class RepositoryQuerySingleContext<T, TKey> : RepositoryQuerySingleContext<T, TKey, T>
        where T : class
    {
        public RepositoryQuerySingleContext(IRepository<T, TKey> repository, ISpecification<T> specification, IQueryOptions<T> queryOptions)
            : base(repository, specification, queryOptions)
        {
        }
    }
}