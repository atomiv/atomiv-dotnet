using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.Common
{
    public abstract class QueryHandler<TRequest, TResponse> : QueryHandler<DatabaseContext, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public QueryHandler(DatabaseContext context) : base(context)
        {
        }
    }
}
