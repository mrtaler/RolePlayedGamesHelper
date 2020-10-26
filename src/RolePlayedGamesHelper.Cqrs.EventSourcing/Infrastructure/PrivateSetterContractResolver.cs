using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RolePlayedGamesHelper.Cqrs.EventSourcing.Infrastructure
{
  public class PrivateSetterContractResolver : DefaultContractResolver
  {
    protected override JsonProperty CreateProperty(
      MemberInfo          member,
      MemberSerialization memberSerialization)
    {
      var prop = base.CreateProperty(member, memberSerialization);

      if (prop.Writable)
      {
        return prop;
      }

      if (member is PropertyInfo property && property.GetSetMethod(true) != null)
      {
        prop.Writable = true;
      }

      return prop;
    }
  }
}
