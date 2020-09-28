using System;
using System.Collections.Generic;
using System.Linq;
using BoardGameHelper.Repository.SharpRepository.Interfaces;
using BoardGameHelper.Repository.SharpRepository.Interfaces.Repository;

namespace BoardGameHelper.Repository
{
    public abstract class UnitOfWorkBase<TContext, TDataContextFactory> :
        IUnitOfWork<TContext, TDataContextFactory>
        where TContext : class
        where TDataContextFactory : IDataContextFactory<TContext>
    {
        protected UnitOfWorkBase()
        {
            RepositoryFactories = new List<object>();
            Repositories = new List<IRepository>();
        }

        public abstract TDataContextFactory DataContextFactory { get; }

        protected readonly List<object> RepositoryFactories;

        protected readonly List<IRepository> Repositories;

        protected abstract IRepositoryFactory CreateRepositoryFactory();

        public IRepositoryFactory GetRepositoryFactory()
        {
            var factory = RepositoryFactories.OfType<IRepositoryFactory>().FirstOrDefault();
            if (factory != null)
            {
                return factory;
            }
            factory = CreateRepositoryFactory();
            if (factory == null)
            {
                throw new ArgumentException($"Could not create repository factory ");
            }
            RepositoryFactories.Add(factory);
            return factory;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            var repo = Repositories.OfType<IRepository<TEntity>>().FirstOrDefault();
            if (repo == null)
            {
                var factory = GetRepositoryFactory();
                repo = factory?.GetInstance<TEntity>();
                if (repo == null)
                {
                    throw new ArgumentException(
                        $"Could not create repository of entity type '<{typeof(TEntity).Name}>'", nameof(TEntity));
                }

                Repositories.Add(repo);
                return repo;
            }

            return repo;
        }
        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class, new()
        {
            var repo = Repositories.OfType<IRepository<TEntity, TKey>>().FirstOrDefault();
            if (repo == null)
            {
                var factory = GetRepositoryFactory();
                repo = factory?.GetInstance<TEntity, TKey>();
                if (repo == null)
                {
                    throw new ArgumentException(
                        $"Could not create repository of entity type '<{typeof(TEntity).Name}>'", nameof(TEntity));
                }

                Repositories.Add(repo);
                return repo;
            }

            return repo;
        }

        public ICompoundKeyRepository<TEntity, TKey, TKey2> GetRepository<TEntity, TKey, TKey2>() where TEntity : class, new()
        {
            var repo = Repositories.OfType<ICompoundKeyRepository<TEntity, TKey, TKey2>>().FirstOrDefault();
            if (repo == null)
            {
                var factory = GetRepositoryFactory();
                repo = factory?.GetInstance<TEntity, TKey, TKey2>();
                if (repo == null)
                {
                    throw new ArgumentException(
                        $"Could not create repository of entity type '<{typeof(TEntity).Name}>'", nameof(TEntity));
                }

                Repositories.Add(repo);
                return repo;
            }

            return repo;
        }

        public ICompoundKeyRepository<TEntity, TKey, TKey2, TKey3> GetRepository<TEntity, TKey, TKey2, TKey3>() where TEntity : class, new()
        {
            var repo = Repositories.OfType<ICompoundKeyRepository<TEntity, TKey, TKey2, TKey3>>().FirstOrDefault();
            if (repo == null)
            {
                var factory = GetRepositoryFactory();
                repo = factory?.GetInstance<TEntity, TKey, TKey2, TKey3>();
                if (repo == null)
                {
                    throw new ArgumentException(
                        $"Could not create repository of entity type '<{typeof(TEntity).Name}>'", nameof(TEntity));
                }

                Repositories.Add(repo);
                return repo;
            }

            return repo;
        }

        public abstract int?  SaveChanges();
    }

    public abstract class RepositoryFactoryBase<TDataContextFactory, TContext> : 
        IRepositoryFactory<TDataContextFactory, TContext>
        where TDataContextFactory : IDataContextFactory<TContext>
        where TContext : class
    {
        public TDataContextFactory DataContextFactory { get; }

        protected RepositoryFactoryBase(TDataContextFactory dataContextFactory)
        {
            DataContextFactory = dataContextFactory;
        }

        /// <inheritdoc />
        public abstract IRepository<T> GetInstance<T>() where T : class, new();

        /// <inheritdoc />
        public abstract IRepository<T, TKey> GetInstance<T, TKey>() where T : class, new();

        /// <inheritdoc />
        public abstract ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>() where T : class, new();

        /// <inheritdoc />
        public abstract ICompoundKeyRepository<T, TKey, TKey2, TKey3> GetInstance<T, TKey, TKey2, TKey3>() where T : class, new();
    }
}