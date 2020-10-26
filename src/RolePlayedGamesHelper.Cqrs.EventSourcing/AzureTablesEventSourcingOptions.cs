using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayedGamesHelper.Cqrs.EventSourcing
{
  public class AzureTablesEventSourcingOptions
  {
    public string TableName { get; set; } = "eventstore";
    public string StorageConnectionString { get; set; }
  }
}
