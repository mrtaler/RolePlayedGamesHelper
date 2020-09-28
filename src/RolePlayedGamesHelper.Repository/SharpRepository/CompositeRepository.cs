using System;
using System.Linq;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.SharpRepository
{
    // right now int is hard coded but it's sloppy and need to fix this inheritance
    public class CompositeRepository<T, TContext> : LinqRepositoryBase<T, int, TContext>
        where T : class
        where TContext : class, IDisposable
    {
        private readonly IQueryable<T> _baseQuery;

        public CompositeRepository(IDataContextFactory<TContext> dataContextFactory, IQueryable<T> baseQuery)
            : base(dataContextFactory)
        {
            _baseQuery = baseQuery;
        }

        protected override IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null)
        {
            return _baseQuery;
        }

        protected override void AddItem(T entity)
        {
            throw new NotImplementedException();
        }

        protected override void DeleteItem(T entity)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateItem(T entity)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {

        }
    }
}
