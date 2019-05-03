using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Ports.In.UseCases
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
