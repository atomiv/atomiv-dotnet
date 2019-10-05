using Optivem.Framework.Core.Common;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidator<TRequest>
        where TRequest : IRequest
    {
        Task<IRequestValidationResult> ValidateAsync(TRequest request);
    }

    public interface IRequestValidator
    {
        Task<IRequestValidationResult> ValidateAsync<TRequest>(TRequest request) where TRequest : IRequest;
    }
}