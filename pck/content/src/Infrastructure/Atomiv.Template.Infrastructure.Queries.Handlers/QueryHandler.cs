using Atomiv.Core.Application;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Atomiv.Template.Infrastructure.Queries.Handlers
{
    public abstract class QueryHandler<TQuery, TResponse> : QueryHandler<DatabaseContext, TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public QueryHandler(DatabaseContext context) : base(context)
        {
        }
    }
}
