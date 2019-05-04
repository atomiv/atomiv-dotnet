using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }

    public interface IUseCase<TResponse>
    {
        Task<TResponse> HandleAsync();
    }
}
