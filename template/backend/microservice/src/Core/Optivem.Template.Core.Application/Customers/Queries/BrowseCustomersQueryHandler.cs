using System;
using System.Linq;
using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Queries.Repositories;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class BrowseCustomersQueryHandler : IRequestHandler<BrowseCustomersQuery, BrowseCustomersQueryResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public BrowseCustomersQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<BrowseCustomersQueryResponse> HandleAsync(BrowseCustomersQuery request)
        {
            return _customerReadRepository.QueryAsync(request);
        }
    }
}