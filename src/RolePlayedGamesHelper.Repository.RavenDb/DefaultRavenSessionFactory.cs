using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Repository.RavenDb.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.RavenDb
{
    public sealed class DefaultRavenSessionFactory : IDataContextFactory<IDocumentSession>
    {
        private readonly IDocumentStore store;
        private IRavenContext currentSession;

        public DefaultRavenSessionFactory(IDocumentStore docStore)
        {
            store = docStore;
        }

        public IDocumentSession GetContext()
        {
            if (currentSession != null)
                return currentSession;
            var openSession = store.OpenSession();
           // currentSession = (IRavenContext)openSession;
            return openSession;
        }

        public void Dispose()
        {
            currentSession?.Dispose();
        }
    }
}
