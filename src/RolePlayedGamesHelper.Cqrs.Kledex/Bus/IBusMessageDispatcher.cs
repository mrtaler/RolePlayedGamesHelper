using System.Threading.Tasks;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Bus
{
    public interface IBusMessageDispatcher
    {
        Task DispatchAsync<TMessage>(TMessage message) where TMessage : IBusMessage;
    }
}
