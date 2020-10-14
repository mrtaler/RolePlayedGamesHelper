using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.SharpRepository.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.Specifications;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public abstract class RepositoryQueryContext<T, TKey> : RepositoryQueryContext<T, TKey, T> where T : class
    {
        protected RepositoryQueryContext(IRepository<T, TKey> repository, ISpecification<T> specification, IQueryOptions<T> queryOptions)
            : base(repository, specification, queryOptions)
        {
        }
    }
}