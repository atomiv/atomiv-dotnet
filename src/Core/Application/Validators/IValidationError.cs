namespace Optivem.Framework.Core.Application.Validators
{
    public interface IValidationError
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}
