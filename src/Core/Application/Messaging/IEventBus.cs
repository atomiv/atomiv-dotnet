using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent evt);
    }
}
