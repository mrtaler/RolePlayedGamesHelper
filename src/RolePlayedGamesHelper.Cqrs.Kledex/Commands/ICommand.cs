﻿using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Commands
{
    public interface ICommand
    {
        string UserId { get; set; }
        string Source { get; set; }
        DateTime TimeStamp { get; set; }
        bool? Validate { get; set; }
        bool? PublishEvents { get; set; }
    }
}
