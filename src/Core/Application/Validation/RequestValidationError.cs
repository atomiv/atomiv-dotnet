using Atomiv.Core.Domain;

namespace Atomiv.Core.Application
{
    public class RequestValidationError
    {
        public RequestValidationError(string propertyName, string errorCode, ValidationErrorType errorType, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorCode = errorCode;
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; }

        public string ErrorCode { get; }

        public ValidationErrorType ErrorType { get; }

        public string ErrorMessage { get; }

        public static RequestValidationError From(RuleValidationResult validationResult)
        {
            // TODO: VC: Add other properties
            return new RequestValidationError(null, null, ValidationErrorType.UnprocessableEntity, validationResult.ErrorMessage);
        }
    }
}
