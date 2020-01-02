using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public interface IMessageBus
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    }
}
