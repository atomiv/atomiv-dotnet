using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IQueryBus
    {
        Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query);
    }
}
