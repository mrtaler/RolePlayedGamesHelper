using System;
using System.Collections.Generic;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes
{
  public class CreateAggregateBusMessage : DomainCommand<Aggregate>, IBusQueueMessage
  {
    public DateTime? ScheduledEnqueueTimeUtc { get; set; }
    public string QueueName { get; set; } = "create-something";
    public IDictionary<string, object> Properties { get; set; }
  }
}
