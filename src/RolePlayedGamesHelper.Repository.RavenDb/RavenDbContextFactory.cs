using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Repository.RavenDb.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.RavenDb
{
    public sealed class RavenDbContextFactory : IDataContextFactory<IDocumentSession>
    {
        private readonly IDocumentStore store;
        private IDocumentSession currentSession;

        public RavenDbContextFactory(IDocumentStore docStore)
        {
            store = docStore;
        }

        public IDocumentSession GetContext()
        {
            if (currentSession != null)
                return currentSession;
            var openSession = store.OpenSession();
            currentSession = openSession;
            return currentSession;
        }

        public void Dispose()
        {
            currentSession?.Dispose();
        }
    }
}
