using System;
using System.Collections.Generic;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Dependencies
{
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
        object Resolve(Type type);
        IEnumerable<object> ResolveAll(Type type);
    }
}
