using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Orders
{
    public class ViewOrdersQueryHandler : QueryHandler<ViewOrderQuery, ViewOrderQueryResponse>
    {
        public ViewOrdersQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override Task<ViewOrderQueryResponse> HandleAsync(ViewOrderQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
