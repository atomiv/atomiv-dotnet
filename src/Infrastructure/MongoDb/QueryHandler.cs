using Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MongoDb
{
    public abstract class QueryHandler<TContext, TRequest, TResponse> : IQueryHandler<TRequest, TResponse>
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
