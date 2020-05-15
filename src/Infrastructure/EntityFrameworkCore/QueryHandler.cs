using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.EntityFrameworkCore
{
    public abstract class QueryHandler<TContext, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TContext : DbContext
        where TRequest : IRequest<TResponse>
    {
        public QueryHandler(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
}
