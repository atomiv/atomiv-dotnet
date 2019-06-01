namespace Optivem.Core.Application
{
    public interface IRequestValidationError
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}