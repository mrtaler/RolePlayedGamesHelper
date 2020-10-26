using AutoMapper;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Events
{
    public class EventFactory : IEventFactory
    {
        private readonly IMapper _mapper;

        public EventFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public dynamic CreateConcreteEvent(object @event)
        {
            var type = @event.GetType();
            dynamic result = _mapper.Map(@event, type, type);
            return result;
        }
    }
}