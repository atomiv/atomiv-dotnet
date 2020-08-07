using Atomiv.Core.Application;
using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb
{
    public abstract class QueryHandler<TRequest, TResponse> : QueryHandler<MongoDbContext, TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
        public QueryHandler(MongoDbContext context) : base(context)
        {
        }
    }
}
