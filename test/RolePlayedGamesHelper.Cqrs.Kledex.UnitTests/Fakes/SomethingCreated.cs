using System;
using System.Collections.Generic;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;
namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes
{
  public class SomethingCreated : Event, IBusQueueMessage
  {
    public DateTime? ScheduledEnqueueTimeUtc { get; set; }
    public string QueueName { get; set; } = "queue-name";
    public IDictionary<string, object> Properties { get; set; }
  }
}
