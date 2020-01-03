namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidationError
    {
        string PropertyName { get; }

        string ErrorCode { get; }

        string ErrorMessage { get; }
    }
}