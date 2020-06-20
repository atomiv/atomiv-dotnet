using Atomiv.Core.Application;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Atomiv.Template.Infrastructure.Queries.Handlers
{
    public abstract class QueryHandler<TRequest, TResponse> : QueryHandler<DatabaseContext, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public QueryHandler(DatabaseContext context) : base(context)
        {
        }
    }
}
