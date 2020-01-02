using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, ListCustomersQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerReadRepository _customerReadRepository;

        public ListCustomersQueryHandler(IMapper mapper, ICustomerReadRepository customerReadRepository)
        {
            _mapper = mapper;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<ListCustomersQueryResponse> HandleAsync(ListCustomersQuery request)
        {
            var listResult = await _customerReadRepository.ListAsync(request.NameSearch, request.Limit);

            return _mapper.Map<ListReadModel<CustomerIdNameReadModel>, ListCustomersQueryResponse>(listResult);
        }
    }
}