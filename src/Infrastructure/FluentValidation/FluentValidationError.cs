using FluentValidation.Results;
using Optivem.Framework.Core.Application;

namespace Optivem.Framework.Infrastructure.FluentValidation
{
    public class FluentValidationError : IRequestValidationError
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