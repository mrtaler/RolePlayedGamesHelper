using System.Collections.Generic;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Bus
{
    public interface IBusMessage
    {
        IDictionary<string, object> Properties { get; set; }
    }
}
