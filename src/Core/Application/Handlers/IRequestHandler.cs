using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IRequestHandler<TRequest>
    {
        Task HandleAsync(TRequest request);
    }

    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}