﻿using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
