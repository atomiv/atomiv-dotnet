using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidator<TRequest>
    {
        Task<IRequestValidationResult> ValidateAsync(TRequest request);
    }

    public interface IRequestValidator
    {
        Task<IRequestValidationResult> ValidateAsync<TRequest>(TRequest request);
    }
}