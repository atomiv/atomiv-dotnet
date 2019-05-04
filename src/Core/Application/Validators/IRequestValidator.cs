namespace Optivem.Core.Application
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
