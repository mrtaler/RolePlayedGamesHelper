using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.SharpRepository.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.Specifications;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public class RepositoryQueryMultipleContext<T, TKey, TResult> : RepositoryQueryContext<T, TKey, TResult>
        where T : class
    {
        public RepositoryQueryMultipleContext(
            IRepository<T, TKey> repository, 
            ISpecification<T> specification, 
            IQueryOptions<T> queryOptions, 
            Expression<Func<T, TResult>> selector = null)
            : base(repository, specification, queryOptions, selector)
        {
        }

        public IEnumerable<TResult> Results { get; set; }
        public override int NumberOfResults => Results == null ? 0 : Results.Count();
    }
}