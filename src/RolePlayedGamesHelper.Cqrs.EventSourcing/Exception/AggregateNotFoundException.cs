using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RolePlayedGamesHelper.Cqrs.EventSourcing.Exception
{
  [Serializable]
  public class AggregateNotFoundException : AggregateExceptionBase
  {
    protected AggregateNotFoundException(SerializationInfo info, StreamingContext context) :
      base(info, context)
    {
    }

    public AggregateNotFoundException(string aggregateId) : base($"Partition Key {aggregateId} does not exist")
    {
    }
  }
}
