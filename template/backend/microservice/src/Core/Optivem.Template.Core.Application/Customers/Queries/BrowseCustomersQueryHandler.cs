using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Template.Core.Application.Customers.Repositories;

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