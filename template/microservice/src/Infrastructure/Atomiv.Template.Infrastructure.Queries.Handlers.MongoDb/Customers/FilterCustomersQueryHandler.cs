using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Customers
{
    public class FilterCustomersQueryHandler : QueryHandler<FilterCustomersQuery, FilterCustomersQueryResponse>
    {
        public FilterCustomersQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override Task<FilterCustomersQueryResponse> HandleAsync(FilterCustomersQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
