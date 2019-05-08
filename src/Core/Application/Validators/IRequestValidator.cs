namespace Optivem.Core.Application
{
    public interface IRequestValidator<TRequest>
        where TRequest : IRequest
    {
        IValidationResult Validate(TRequest request);
    }

    public interface IRequestValidator
    {
        IValidationResult Validate<TRequest>(TRequest request) where TRequest : IRequest;
    }
}
