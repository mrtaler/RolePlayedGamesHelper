using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Exceptions
{
    public class QueryException : Exception
    {
        public QueryException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
