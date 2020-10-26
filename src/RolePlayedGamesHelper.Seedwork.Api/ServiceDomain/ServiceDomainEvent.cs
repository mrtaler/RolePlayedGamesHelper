using System;
using System.Collections.Generic;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;

namespace RolePlayedGamesHelper.Seedwork.Api.ServiceDomain
{
  /// <summary>
  /// The service domain event.
  /// </summary>
  public class ServiceDomainEvent : Event, IDomainEvent, IBusTopicMessage
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceDomainEvent"/> class.
    /// </summary>
    /// <param name="code">
    /// The code.
    /// </param>
    /// <param name="message">
    /// The message.
    /// </param>
    public ServiceDomainEvent(string code, string message)
    {
      Code = code;
      Message = message;
    }

    /// <summary>
    /// Gets the code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the command id.
    /// </summary>
    public Guid CommandId { get; set; }

    /// <summary>
    /// Gets or sets the scheduled enqueue time utc.
    /// </summary>
    public DateTime? ScheduledEnqueueTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the properties.
    /// </summary>
    public IDictionary<string, object> Properties { get; set; }

    /// <summary>
    /// Gets or sets the topic name.
    /// </summary>
    public string TopicName { get; set; } = "gurpsgeneraltopic";

    /// <summary>
    /// Gets or sets the aggregate root id.
    /// </summary>
    public Guid AggregateRootId
    {
      get => Guid.Parse("131B067D-8B2C-4C5B-A4E0-97C3D59D95B8");
      set { }
    }

    /// <summary>
    /// The update.
    /// </summary>
    /// <param name="command">
    /// The command.
    /// </param>
    /// <exception cref="NotImplementedException"> Not Implemented Exception
    /// </exception>
    public void Update(IDomainCommand command)
    {
      throw new NotImplementedException();
    }
  }
}
