using FluentValidation.Results;
using Atomiv.Core.Application;
using System.Linq;

namespace Atomiv.Infrastructure.FluentValidation
{
    public static class ValidationResultExtensions
    {
        public static RequestValidationResult ToRequestValidationResult(this ValidationResult result)
        {
            var isValid = result.IsValid;

            var errors = result.Errors
                .Select(GetRequestValidationError)
                .ToList();

            return new RequestValidationResult(isValid, errors);
        }

        private static RequestValidationError GetRequestValidationError(ValidationFailure failure)
        {
            var propertyName = failure.PropertyName;
            var errorCode = failure.ErrorCode;
            var errorMessage = failure.ErrorMessage;
            var errorType = ValidationErrorType.UnprocessableEntity; // TODO: VC: Previously it was throw exception

            return new RequestValidationError(propertyName, errorCode, errorType, errorMessage);
        }
    }
}
