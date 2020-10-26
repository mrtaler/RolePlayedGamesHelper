﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Bus.ServiceBus.Factories
{
    public class MessageFactory : IMessageFactory
    {
        public static readonly string AssemblyQualifiedNamePropertyName = "AssemblyQualifiedName";
        /// <inheritdoc />
        public Message CreateMessage<TMessage>(TMessage message) where TMessage : IBusMessage
        {
            var json = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(json))
            {
                ContentType = "application/json"
            };

            if (message.Properties != null)
            {
                foreach (var prop in message.Properties)
                {
                    // We could use reflexion here, but i believe we should bet on performace and simplicity.
                    // If not, then we can consider adding more of this properties
                    if (prop.Key == nameof(serviceBusMessage.Label))
                        serviceBusMessage.Label = message.Properties[prop.Key] as string;
                    else if (prop.Key == nameof(serviceBusMessage.SessionId))
                        serviceBusMessage.SessionId = message.Properties[prop.Key] as string;
                    else if (prop.Key == nameof(serviceBusMessage.CorrelationId))
                        serviceBusMessage.CorrelationId = message.Properties[prop.Key] as string;
                    else if (prop.Key == nameof(serviceBusMessage.ScheduledEnqueueTimeUtc) && message.Properties[prop.Key] is DateTime ScheduledEnqueueTimeUtc)
                        serviceBusMessage.ScheduledEnqueueTimeUtc = ScheduledEnqueueTimeUtc;
                    else
                        serviceBusMessage.UserProperties.Add(prop.Key, prop.Value);
                }
            }

            //NOTE: we keep prop mapping this for legacy users, it's been marked as obsolete and should be removed in a future release
            if (message.ScheduledEnqueueTimeUtc.HasValue
                && message.Properties != null
                && !message.Properties.ContainsKey(nameof(message.ScheduledEnqueueTimeUtc)))
                serviceBusMessage.ScheduledEnqueueTimeUtc = message.ScheduledEnqueueTimeUtc.Value;

            serviceBusMessage.UserProperties.Add(new KeyValuePair<string, object>(AssemblyQualifiedNamePropertyName, message.GetType().AssemblyQualifiedName));

            return serviceBusMessage;
        }
    }
}