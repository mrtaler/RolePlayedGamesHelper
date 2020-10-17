using System;
using System.Data.Common;
using System.Data.Entity;
using RolePlayedGamesHelper.Repository.EntityFramework.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.EntityFramework
{
    public class DbEfUnitOfWork<TContext> : UnitOfWorkBase<TContext, DbEfContextFactory<TContext>>
        where TContext : DbContext, IEfDbContext
    {
        private DbConnection options;
        private bool isDisposed;

        public DbEfUnitOfWork(DbConnection options, DbEfContextFactory<TContext> factory)
        {
            this.options       = options;
            DataContextFactory = factory;
        }

        /// <inheritdoc />
        public override DbEfContextFactory<TContext> DataContextFactory { get; }

        /// <inheritdoc />
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                DataContextFactory.GetContext().Dispose();
            }
            // Free any unmanaged objects here.
            //
            isDisposed = true;
        }

        /// <inheritdoc />
        protected override IRepositoryFactory CreateRepositoryFactory()
        {
            return new DbEfRepositoryFactory<TContext>(DataContextFactory);
        }

        /// <inheritdoc />
        public override int? SaveChanges()
        {
            return DataContextFactory.GetContext().SaveChanges();
        }

        ~DbEfUnitOfWork()
        {
            Dispose(false);
        }
    }
}
