using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Entities
{
    public class AggregateEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
