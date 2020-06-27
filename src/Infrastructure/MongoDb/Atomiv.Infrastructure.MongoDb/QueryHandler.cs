using Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MongoDb
{
    public abstract class QueryHandler<TContext, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
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
