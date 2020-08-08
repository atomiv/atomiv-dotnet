using Atomiv.Core.Application;
using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB
{
    public abstract class QueryHandler<TRequest, TResponse> : QueryHandler<MongoDBContext, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public QueryHandler(MongoDBContext context) : base(context)
        {
        }
    }
}
