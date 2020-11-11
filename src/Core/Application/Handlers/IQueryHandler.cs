using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        new Task<TResponse> HandleAsync(TQuery query);
    }
}
