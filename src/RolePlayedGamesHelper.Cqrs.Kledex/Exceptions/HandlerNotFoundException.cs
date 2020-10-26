using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Exceptions
{
    public class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(Type handlerType)
            : base(BuildErrorMessage(handlerType))
        {
        }

        private static string BuildErrorMessage(Type handlerType)
        {
            return $"No handler found that implements '{handlerType.FullName}'";
        }
    }
}