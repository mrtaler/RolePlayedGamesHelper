using System;
using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using RolePlayedGamesHelper.Cqrs.Kledex.Models;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Services
{
    public interface IDomainService
    {
        Task<AggregateModel> GetAggregateAsync(Guid aggregateId);
        Task SaveStoreDataAsync(SaveStoreData request);
    }
}
