using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IEventHandler<TEvent>
    {
        Task HandleAsync(TEvent evt);
    }
}
