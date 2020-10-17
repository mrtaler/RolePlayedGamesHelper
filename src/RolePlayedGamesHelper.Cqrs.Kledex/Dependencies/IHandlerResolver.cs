﻿using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Dependencies
{
    public interface IHandlerResolver
    {
        THandler ResolveHandler<THandler>();
        object ResolveHandler(Type handlerType);
        object ResolveHandler(object param, Type type);
    }
}
