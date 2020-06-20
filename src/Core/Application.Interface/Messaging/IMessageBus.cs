using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IMessageBus
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    }
}
