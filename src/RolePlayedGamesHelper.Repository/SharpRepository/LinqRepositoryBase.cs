using System;
using System.Linq;
using System.Linq.Expressions;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.SharpRepository.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.RepositoryBase;
using RolePlayedGamesHelper.Repository.SharpRepository.Specifications;

namespace RolePlayedGamesHelper.Repository.SharpRepository
{
    public abstract class LinqRepositoryBase<T, TKey, TContext> : RepositoryBase<T, TKey, TContext>
        where T : class
        where TContext : class, IDisposable
    {
        protected LinqRepositoryBase(IDataContextFactory<TContext> dataContextFactory, ICachingStrategy<T, TKey> cachingStrategy = null)
            : base(dataContextFactory, cachingStrategy)
        {
        }

        public override IQueryable<T> AsQueryable()
        {
            return BaseQuery();
        }

        protected override T GetQuery(TKey key, IFetchStrategy<T> fetchStrategy)
        {
            return FindQuery(ByPrimaryKeySpecification(key, fetchStrategy));
        }

        protected override T FindQuery(ISpecification<T> criteria)
        {
            var query = BaseQuery(criteria.FetchStrategy);

            SetTraceInfo("Find", query);

            return criteria.SatisfyingEntityFrom(query);
        }

        protected override T FindQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions)
        {
            if (queryOptions == null)
                return FindQuery(criteria);

            var query = queryOptions.Apply(BaseQuery(criteria.FetchStrategy));

            SetTraceInfo("Find", query);

            return criteria.SatisfyingEntityFrom(query);
        }

        protected override IQueryable<T> GetAllQuery(IFetchStrategy<T> fetchStrategy)
        {
            var query = BaseQuery(fetchStrategy);

            SetTraceInfo("GetAll", query);

            return query;
        }

        protected override IQueryable<T> GetAllQuery(IQueryOptions<T> queryOptions, IFetchStrategy<T> fetchStrategy)
        {
            if (queryOptions == null)
                return GetAllQuery(fetchStrategy);

            var query = BaseQuery(fetchStrategy);

            query = queryOptions.Apply(query);

            SetTraceInfo("GetAll", query);

            return query;
        }

        protected override IQueryable<T> FindAllQuery(ISpecification<T> criteria)
        {
            var query = BaseQuery(criteria.FetchStrategy);
            query = criteria.SatisfyingEntitiesFrom(query);

            SetTraceInfo("FindAll", query);

            return query;
        }

        protected override IQueryable<T> FindAllQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions)
        {
            if (queryOptions == null)
                return FindAllQuery(criteria);

            var query = BaseQuery(criteria.FetchStrategy);

            query = criteria.SatisfyingEntitiesFrom(query);

            query = queryOptions.Apply(query);

            SetTraceInfo("FindAll", query);

            return query;
        }

        public override IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(IRepositoryQueryable<TInner> innerRepository, Expression<Func<T, TJoinKey>> outerKeySelector, Expression<Func<TInner, TJoinKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
        {
            var innerQuery = innerRepository.AsQueryable();
            var outerQuery = BaseQuery();

            var innerType = innerRepository.GetType();
            var outerType = GetType();
            var outerKeySelectorFunc = outerKeySelector.Compile();
            var innerKeySelectorFunc = innerKeySelector.Compile();
            var resultSelectorFunc = resultSelector.Compile();

            // if these are 2 different Repository types then let's bring down each query into memory so that they can be joined
            // if they are the same type then they will use the native IQueryable and take advantage of the back-end side join if possible
            if (innerType.Name != outerType.Name)
            {
                innerQuery = innerQuery.ToList().AsQueryable();
                outerQuery = outerQuery.ToList().AsQueryable();
            }

            var query = outerQuery.Join(innerQuery, outerKeySelectorFunc, innerKeySelectorFunc, resultSelectorFunc).AsQueryable();
            SetTraceInfo("Join", query);
            return new CompositeRepository<TResult, TContext>(DataContextFactory,query);
        }
    }
}
