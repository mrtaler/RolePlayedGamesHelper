using System;
using System.Collections.Generic;
using Autofac;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;
using RolePlayedGamesHelper.Repository.Xml.SharpRepository;

namespace RolePlayedGamesHelper.Repository.Xml
{
    //  public abstract class UnitOfWorkBase<TContext>
    public partial class XmlUnitOfWork
        : UnitOfWorkBase<string, XmlContextFactory>
    {
        private List<string> repositories = new List<string>();

        private ILifetimeScope scope;
        public XmlUnitOfWork(ILifetimeScope container, XmlContextFactory dataContextFactory)
        {
            scope = container.BeginLifetimeScope();
            DataContextFactory = dataContextFactory;
        }

        private bool _isDisposed;

        /// <inheritdoc />
        public override XmlContextFactory DataContextFactory { get; }

        /// <inheritdoc />
        protected override IRepositoryFactory CreateRepositoryFactory()
        {
            return new XmlRepositoryFactory(DataContextFactory);
        }

        /// <inheritdoc />
        public override int? SaveChanges()
        {
            try
            {
                foreach (var repository in Repositories)
                {
                    var rep = (IXmlRepositoryBase)repository;
                    rep.SaveChanges();
                }

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

        ~XmlUnitOfWork()
        {
            Dispose(false);
        }
    }
}
