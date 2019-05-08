using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public interface IRequestValidator<TRequest>
        where TRequest : IRequest
    {
        Task<IValidationResult> ValidateAsync(TRequest request);
    }

    public interface IRequestValidator
    {
        Task<IValidationResult> ValidateAsync<TRequest>(TRequest request) where TRequest : IRequest;
    }
}
