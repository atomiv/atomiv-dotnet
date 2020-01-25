using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Repositories;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, ListCustomersQueryResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public ListCustomersQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<ListCustomersQueryResponse> HandleAsync(ListCustomersQuery request)
        {
            return _customerReadRepository.QueryAsync(request);
        }
    }
}