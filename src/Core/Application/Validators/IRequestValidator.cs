using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public interface IRequestValidator<TRequest>
    {
        Task<RequestValidationResult> ValidateAsync(TRequest request);
    }
}