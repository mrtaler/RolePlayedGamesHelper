using System;
using Raven.Client.Documents.Session;

namespace RolePlayedGamesHelper.Repository.RavenDb.SharpRepository
{
    /// <summary>
    /// RavenDb repository layer
    /// </summary>
    /// <typeparam name="T">The type of object the repository acts on.</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public class RavenDbRepository<TEntity, TKey, TContext> : RavenDbRepositoryBase<TEntity, TKey, TContext>
        where TEntity : class
        where TContext : class, IDocumentSession, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RavenDbRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="cachingStrategy">The caching strategy.  Defaults to <see cref="NoCachingStrategy{T}" />.</param>
        public RavenDbRepository(
            IDataContextFactory<TContext> dataContextFactory,
            ICachingStrategy<TEntity, TKey> cachingStrategy = null) 
            : base(dataContextFactory, cachingStrategy)
        {
        }
    }

    /// <summary>
    /// RavenDb repository layer
    /// </summary>
    /// <typeparam name="T">The type of object the repository acts on.</typeparam>
    public class RavenDbRepository<TEntity, TContext> : RavenDbRepositoryBase<TEntity, string, TContext>
        where TEntity : class
        where TContext : class, IDocumentSession, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RavenDbRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="cachingStrategy">The caching strategy.  Defaults to <see cref="NoCachingStrategy&lt;T&gt;" />.</param>
        public RavenDbRepository(IDataContextFactory<TContext> dataContextFactory, ICachingStrategy<TEntity, string> cachingStrategy = null)
            : base(dataContextFactory, cachingStrategy)
        {
        }
    }
}