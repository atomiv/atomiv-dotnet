using FluentValidation.Results;
using Optivem.Framework.Core.Application.Validators;

namespace Optivem.Framework.Infrastructure.Application.Validators.FluentValidation
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
