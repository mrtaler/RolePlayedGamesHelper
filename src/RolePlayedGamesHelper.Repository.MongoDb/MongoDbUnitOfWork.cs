using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.MongoDb
{
    public class MongoDbUnitOfWork : UnitOfWorkBase<IMongoClient, MongoDbContextFactory>
    {
        private bool _isDisposed;
        private readonly IMongoDatabase _mongoDbDatabase;

        public MongoDbUnitOfWork(MongoDbConfiguration configuration)
        {
            DataContextFactory = new MongoDbContextFactory(configuration);
            _mongoDbDatabase = DataContextFactory.GetContext().GetDatabase(configuration.DatabaseName);
        }
        /// <inheritdoc />
        public override MongoDbContextFactory DataContextFactory { get; }


        /// <inheritdoc />
        protected override IRepositoryFactory CreateRepositoryFactory()
        {
            return new MongoRepositoryFactory(DataContextFactory);
        }

        /// <inheritdoc />
        public override int? SaveChanges()
        {
            try
            {
                var tm = DataContextFactory.GetContext().StartSession();
                tm.CommitTransaction();
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

        // Protected implementation of Dispose pattern.
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
        ~MongoDbUnitOfWork()
        {
            Dispose(false);
        }
    }
}
