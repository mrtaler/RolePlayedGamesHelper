using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.RavenDb.SharpRepository
{
    public class DefaultRavenSessionFactory<TContext> : IDataContextFactory<TContext>
        where TContext : class, IDocumentSession
    {
        private readonly IDocumentStore store;
        private TContext currentSession;

        public DefaultRavenSessionFactory(IDocumentStore docStore)
        {
            store = docStore;
        }

        public TContext GetContext()
        {
            if (currentSession != null)
                return currentSession;
            var openSession = store.OpenSession();
            currentSession = (TContext)openSession;
            return currentSession;
        }

        public void Dispose()
        {
            currentSession?.Dispose();
        }
    }
}
