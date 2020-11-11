using Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MongoDB
{
    public abstract class QueryHandler<TContext, TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public QueryHandler(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public abstract Task<TResponse> HandleAsync(TQuery request);
    }
}
