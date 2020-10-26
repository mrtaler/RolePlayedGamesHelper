using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb.Documents.Factories
{
    public interface IAggregateDocumentFactory
    {
        AggregateDocument CreateAggregate(Type aggregateType, Guid aggregateRootId);
    }
}