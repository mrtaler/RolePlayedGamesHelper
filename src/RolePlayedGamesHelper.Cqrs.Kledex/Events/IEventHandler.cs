namespace RolePlayedGamesHelper.Cqrs.Kledex.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
