using System;
using System.Runtime.Serialization;

namespace RolePlayedGamesHelper.Cqrs.EventSourcing.Exception
{
  [Serializable]
  public class ConcurrencyException : AggregateExceptionBase
  {
    protected ConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ConcurrencyException(string message) : base(message)
    {
    }

    public ConcurrencyException(string message, System.Exception inner) : base(message, inner)
    {
    }
  }
}