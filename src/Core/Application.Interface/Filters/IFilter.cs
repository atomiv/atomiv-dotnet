using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public interface IFilter<TRequest>
        where TRequest : IRequest
    {
        Task HandleAsync(TRequest request);
    }
}