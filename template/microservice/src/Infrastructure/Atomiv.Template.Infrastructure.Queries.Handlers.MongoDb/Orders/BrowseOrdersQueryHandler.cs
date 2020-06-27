using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Orders
{
    public class BrowseOrdersQueryHandler : QueryHandler<BrowseOrdersQuery, BrowseOrdersQueryResponse>
    {
        public BrowseOrdersQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override Task<BrowseOrdersQueryResponse> HandleAsync(BrowseOrdersQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
