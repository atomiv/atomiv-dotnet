namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidationError
    {
        string PropertyName { get; }

        string ErrorCode { get; }

        ValidationErrorType ErrorType { get; }

        string ErrorMessage { get; }
    }
}