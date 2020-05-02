using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public interface IRequestValidator<TRequest>
    {
        Task<IRequestValidationResult> ValidateAsync(TRequest request);
    }
}