namespace Optivem.Core.Application
{
    public interface IValidationError
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}
