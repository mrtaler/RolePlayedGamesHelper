using System.Threading.Tasks;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> 
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
