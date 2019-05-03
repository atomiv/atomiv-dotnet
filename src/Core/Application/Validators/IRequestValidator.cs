namespace Optivem.Framework.Core.Application.Ports.Out.Validators
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
