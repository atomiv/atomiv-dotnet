using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Optivem.Atomiv.Template.Infrastructure.Queries.Handlers
{
    public abstract class QueryHandler<TRequest, TResponse> : QueryHandler<DatabaseContext, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public QueryHandler(DatabaseContext context) : base(context)
        {
        }
    }
}
