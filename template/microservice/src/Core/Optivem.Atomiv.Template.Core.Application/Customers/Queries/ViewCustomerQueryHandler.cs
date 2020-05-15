using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class ViewCustomerQueryHandler : IRequestHandler<ViewCustomerQuery, ViewCustomerQueryResponse>
    {
        private readonly ICustomerQueryRepository _customerReadRepository;

        public ViewCustomerQueryHandler(ICustomerQueryRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<ViewCustomerQueryResponse> HandleAsync(ViewCustomerQuery request)
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