using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Queries.Repositories;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    // TODO: VC: Make base class with AsNoTracking

    public class FindCustomerQueryHandler : IRequestHandler<FindCustomerQuery, FindCustomerQueryResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public FindCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<FindCustomerQueryResponse> HandleAsync(FindCustomerQuery request)
        {
            var customerDetail = await _customerReadRepository.QueryAsync(request);

            if (customerDetail == null)
            {
                throw new NotFoundRequestException();
            }

            return customerDetail;
        }
    }
}