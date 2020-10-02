using System;
using Autofac;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Repository.RavenDb.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.RavenDb
{
    //  public abstract class UnitOfWorkBase<TContext>
    public partial class RavenUnitOfWork
        : UnitOfWorkBase<IDocumentSession, RavenDbContextFactory>
    {
        private ILifetimeScope scope;
        public RavenUnitOfWork(ILifetimeScope container, RavenDbContextFactory dataContextFactory)
        {
            scope = container.BeginLifetimeScope();
            DataContextFactory = dataContextFactory;
        }

        private bool _isDisposed;

        /// <inheritdoc />
        public override RavenDbContextFactory DataContextFactory { get; }

        /// <inheritdoc />
        protected override IRepositoryFactory CreateRepositoryFactory()
        {
            return new RavenDbRepositoryFactory(DataContextFactory);
        }

        /// <inheritdoc />
        public override int? SaveChanges()
        {
            try
            {
                DataContextFactory.GetContext().SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                //ContextSource.Client.;
            }
            // Free any unmanaged objects here.
            //
            _isDisposed = true;
        }

        ~RavenUnitOfWork()
        {
            Dispose(false);
        }
    }
}
