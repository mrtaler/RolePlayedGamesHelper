using System;
using RolePlayedGamesHelper.Repository.RavenDb.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.RavenDb
{
    //  public abstract class UnitOfWorkBase<TContext>
    public partial class RavenUnitOfWork<TContext>
        : UnitOfWorkBase<TContext>, IUnitOfWork, IDisposable
        where TContext : class, IRavenContext, IDisposable
    {

        protected RavenUnitOfWork(IDataContextFactory<TContext> dataContextFactory)
            : base(dataContextFactory)
        {
        }

        public void Dispose()
        {
            DataContext?.Dispose();
        }

        public override int? SaveChanges()
        {
            try
            {
                DataContext?.SaveChanges();
                return 1;
            }
            catch 
            {
                return null;
            }
        }
    }
}
