using System;
using System.Threading.Tasks;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;

namespace RolePlayedGamesHelper.Cqrs.Kledex.Validation
{
    public interface IValidationProvider
    {
        Task<ValidationResponse> ValidateAsync(ICommand command);
        ValidationResponse Validate(ICommand command);
    }

    public class DefaultValidationProvider : IValidationProvider
    {
        public Task<ValidationResponse> ValidateAsync(ICommand command)
        {
            throw new NotImplementedException(Consts.ValidationRequiredMessage);
        }

        public ValidationResponse Validate(ICommand command)
        {
            throw new NotImplementedException(Consts.ValidationRequiredMessage);
        }
    }
}
