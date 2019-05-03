namespace Optivem.Framework.Core.Application.Ports.Validators
{
    public interface IRequestValidator<TRequest>
    {
        IValidationResult Validate(TRequest request);
    }

    public interface IRequestValidator
    {
        IValidationResult Validate<TRequest>(TRequest request);
    }
}
