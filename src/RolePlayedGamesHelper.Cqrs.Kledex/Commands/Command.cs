﻿using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public abstract class Command : ICommand
    {
        public string UserId { get; set; }
        public string Source { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public bool? Validate { get; set; }
        public bool? PublishEvents { get; set; }       
    }
}
