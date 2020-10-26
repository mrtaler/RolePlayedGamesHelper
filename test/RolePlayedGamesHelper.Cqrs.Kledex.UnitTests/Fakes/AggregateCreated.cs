using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using System;
using System.Collections.Generic;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes
{
  public class AggregateCreated : DomainEvent, IBusQueueMessage
  {
    public DateTime? ScheduledEnqueueTimeUtc { get; set; }
    public string QueueName { get; set; } = "queue-name";
    public IDictionary<string, object> Properties { get; set; }
  }
}
