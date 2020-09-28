using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.SharpRepository.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.Specifications;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public class RepositoryQueryMultipleContext<T, TKey> : RepositoryQueryMultipleContext<T, TKey, T> 
        where T : class
    {
        public RepositoryQueryMultipleContext(
            IRepository<T, TKey> repository,
            ISpecification<T> specification,
            IQueryOptions<T> queryOptions)
            : base(repository, specification, queryOptions, null)
        {
        }
    }
}