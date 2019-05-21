using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public interface IHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}