using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IRequestValidator<TRequest>
    {
        Task<RequestValidationResult> ValidateAsync(TRequest request);
    }
}