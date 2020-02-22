using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class FilterCustomersQueryHandler : IRequestHandler<FilterCustomersQuery, FilterCustomersQueryResponse>
    {
        private readonly ICustomerQueryRepository _customerReadRepository;

        public FilterCustomersQueryHandler(ICustomerQueryRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<FilterCustomersQueryResponse> HandleAsync(FilterCustomersQuery request)
        {
            return _customerReadRepository.QueryAsync(request);
        }
    }
}