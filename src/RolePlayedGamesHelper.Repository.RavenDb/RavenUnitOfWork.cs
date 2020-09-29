using System;
using Autofac;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Repository.RavenDb.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.RavenDb
{
    //  public abstract class UnitOfWorkBase<TContext>
    public partial class RavenUnitOfWork
        : UnitOfWorkBase<IDocumentSession, IDataContextFactory<IDocumentSession>>
    {
        private ILifetimeScope scope;
        public RavenUnitOfWork(IContainer container, IDataContextFactory<IDocumentSession> dataContextFactory)
        {
            scope = container.BeginLifetimeScope();
            DataContextFactory = dataContextFactory;
        }

        private bool _isDisposed;

        /// <inheritdoc />
        public override IDataContextFactory<IDocumentSession> DataContextFactory { get; }

        /// <inheritdoc />
        protected override IRepositoryFactory CreateRepositoryFactory()
        {
            return scope.Resolve<IRepositoryFactory>();
        }

        /// <inheritdoc />
        public override int? SaveChanges()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
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
