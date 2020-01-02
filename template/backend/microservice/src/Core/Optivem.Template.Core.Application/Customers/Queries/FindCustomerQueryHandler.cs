using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class FindCustomerQueryHandler : IRequestHandler<FindCustomerQuery, FindCustomerQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerReadRepository _customerReadRepository;

        public FindCustomerQueryHandler(IMapper mapper, ICustomerReadRepository customerReadRepository)
        {
            _mapper = mapper;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<FindCustomerQueryResponse> HandleAsync(FindCustomerQuery request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var customerDetail = await _customerReadRepository.GetDetailAsync(customerId);

            if (customerDetail == null)
            {
                throw new NotFoundRequestException();
            }

            return _mapper.Map<CustomerDetailReadModel, FindCustomerQueryResponse>(customerDetail);
        }
    }
}