using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.EntityFrameworkCore
{
    public abstract class QueryHandler<TContext, TRequest, TResponse> : IQueryHandler<TRequest, TResponse>
        where TContext : DbContext
        where TRequest : IQuery<TResponse>
    {
        public QueryHandler(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
}
