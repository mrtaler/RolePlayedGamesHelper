﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;
using RolePlayedGamesHelper.Cqrs.Kledex.Exceptions;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Validation
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationProvider _validationProvider;

        public ValidationService(IValidationProvider validationProvider)
        {
            _validationProvider = validationProvider;
        }

        /// <inheritdoc />
        public async Task ValidateAsync(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var validationResponse = await _validationProvider.ValidateAsync(command);

            if (!validationResponse.IsValid)
                throw new ValidationException(BuildErrorMessage(validationResponse.Errors));
        }

        /// <inheritdoc />
        public void Validate(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var validationResponse = _validationProvider.Validate(command);

            if (!validationResponse.IsValid)
                throw new ValidationException(BuildErrorMessage(validationResponse.Errors));
        }

        private static string BuildErrorMessage(IEnumerable<ValidationError> errors)
        {
            var errorsText = errors.Select(x => $"\r\n - {x.ErrorMessage}").ToArray();
            return $"Validation failed: {string.Join("", errorsText)}";
        }
    }
}
