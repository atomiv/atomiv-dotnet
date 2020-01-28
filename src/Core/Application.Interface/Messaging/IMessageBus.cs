using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public interface IMessageBus
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    }
}
