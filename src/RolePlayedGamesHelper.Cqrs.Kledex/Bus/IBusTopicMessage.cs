﻿namespace RolePlayedGamesHelper.Cqrs.Kledex.Bus
{
    public interface IBusTopicMessage : IBusMessage
    {
        string TopicName { get; set; }
    }
}
