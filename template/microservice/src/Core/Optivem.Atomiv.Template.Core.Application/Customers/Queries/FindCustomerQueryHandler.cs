using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    // TODO: VC: Make base class with AsNoTracking

    public class FindCustomerQueryHandler : IRequestHandler<FindCustomerQuery, FindCustomerQueryResponse>
    {
        private readonly ICustomerQueryRepository _customerReadRepository;

        public FindCustomerQueryHandler(ICustomerQueryRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<FindCustomerQueryResponse> HandleAsync(FindCustomerQuery request)
        {
            var customerDetail = await _customerReadRepository.QueryAsync(request);

            if (customerDetail == null)
            {
                throw new ExistenceException();
            }

            return customerDetail;
        }
    }
}