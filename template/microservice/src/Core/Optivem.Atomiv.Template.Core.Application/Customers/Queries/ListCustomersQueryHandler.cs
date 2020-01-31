using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, ListCustomersQueryResponse>
    {
        private readonly ICustomerQueryRepository _customerReadRepository;

        public ListCustomersQueryHandler(ICustomerQueryRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<ListCustomersQueryResponse> HandleAsync(ListCustomersQuery request)
        {
            return _customerReadRepository.QueryAsync(request);
        }
    }
}