using Atomiv.Core.Application;
using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb
{
    public abstract class QueryHandler<TQuery, TResponse> : QueryHandler<MongoDbContext, TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public QueryHandler(MongoDbContext context) : base(context)
        {
        }
    }
}
