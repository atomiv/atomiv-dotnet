namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidationError
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}