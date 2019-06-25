using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        Task HandleAsync(TRequest request);
    }

    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
    public interface IRequestHandler
    {
        Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest
            where TResponse : IResponse;
    }
}