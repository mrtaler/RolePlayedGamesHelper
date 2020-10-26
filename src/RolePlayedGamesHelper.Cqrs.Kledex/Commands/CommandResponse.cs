using System.Collections.Generic;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public class CommandResponse
    {
        public IEnumerable<IEvent> Events { get; set; } = new List<IEvent>();
        public object Result { get; set; }
    }
}
