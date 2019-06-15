using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;

namespace Optivem.NorthwindLite.Infrastructure.MediatR.Customers
{
    public class ListCustomersMediatorRequestHandler : MediatorRequestHandler<ListCustomersRequest, ListCustomersResponse>
    {
        public ListCustomersMediatorRequestHandler(IUseCase<ListCustomersRequest, ListCustomersResponse> useCase)
            : base(useCase)
        {
        }
    }
}