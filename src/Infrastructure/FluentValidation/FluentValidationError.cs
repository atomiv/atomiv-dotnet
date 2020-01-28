using FluentValidation.Results;
using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Infrastructure.FluentValidation
{
    public class FluentValidationError : IRequestValidationError
    {
        private ValidationFailure _failure;

        public FluentValidationError(ValidationFailure failure)
        {
            _failure = failure;
        }

        public string PropertyName => _failure.PropertyName;

        public string ErrorCode => _failure.ErrorCode;

        public string ErrorMessage => _failure.ErrorMessage;

        public ValidationErrorType ErrorType => throw new System.NotImplementedException();
    }
}