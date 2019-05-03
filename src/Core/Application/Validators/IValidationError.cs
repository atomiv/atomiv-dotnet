namespace Optivem.Framework.Core.Application.Ports.Out.Validators
{
    public interface IValidationError
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}
