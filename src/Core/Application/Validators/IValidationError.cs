namespace Optivem.Framework.Core.Application.Ports.Validators
{
    public interface IValidationError
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}
