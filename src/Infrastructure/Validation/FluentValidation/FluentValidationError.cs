using FluentValidation.Results;
using Optivem.Core.Application;

namespace Optivem.Infrastructure.Validation.FluentValidation
{
    public class FluentValidationError : IValidationError
    {
        private ValidationFailure _failure;

        public FluentValidationError(ValidationFailure failure)
        {
            _failure = failure;
        }

        public string PropertyName => _failure.PropertyName;

        public string ErrorMessage => _failure.ErrorMessage;
    }
}