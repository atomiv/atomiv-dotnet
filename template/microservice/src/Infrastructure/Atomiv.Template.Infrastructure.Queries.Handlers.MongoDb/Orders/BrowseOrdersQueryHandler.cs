using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Orders
{
    public class BrowseOrdersQueryHandler : QueryHandler<BrowseOrdersQuery, BrowseOrdersQueryResponse>
    {
        public BrowseOrdersQueryHandler(MongoDBContext context) : base(context)
        {
        }

        public override Task<BrowseOrdersQueryResponse> HandleAsync(BrowseOrdersQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
