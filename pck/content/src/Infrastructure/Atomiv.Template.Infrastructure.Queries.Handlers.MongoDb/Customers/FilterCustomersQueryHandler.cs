using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Customers
{
    public class FilterCustomersQueryHandler : QueryHandler<FilterCustomersQuery, FilterCustomersQueryResponse>
    {
        public FilterCustomersQueryHandler(MongoDBContext context) : base(context)
        {
        }

        public override Task<FilterCustomersQueryResponse> HandleAsync(FilterCustomersQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
