using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using System.Threading.Tasks;

namespace Optivem.Core.Application.Handlers
{
    public interface IHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}
