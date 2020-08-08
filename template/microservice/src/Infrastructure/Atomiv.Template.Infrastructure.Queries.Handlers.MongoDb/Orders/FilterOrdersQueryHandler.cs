using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Orders
{
    public class FilterOrdersQueryHandler : QueryHandler<FilterOrdersQuery, FilterOrdersQueryResponse>
    {
        public FilterOrdersQueryHandler(MongoDBContext context) : base(context)
        {
        }

        public override Task<FilterOrdersQueryResponse> HandleAsync(FilterOrdersQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
