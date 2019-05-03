namespace Optivem.Framework.Core.Application.Validators
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
