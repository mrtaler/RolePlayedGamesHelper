using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities
{
    public class AggregateEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
