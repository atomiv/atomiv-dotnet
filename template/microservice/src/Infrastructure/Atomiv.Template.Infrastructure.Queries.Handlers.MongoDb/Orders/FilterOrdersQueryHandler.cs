using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Orders
{
    public class FilterOrdersQueryHandler : QueryHandler<FilterOrdersQuery, FilterOrdersQueryResponse>
    {
        public FilterOrdersQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override Task<FilterOrdersQueryResponse> HandleAsync(FilterOrdersQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
