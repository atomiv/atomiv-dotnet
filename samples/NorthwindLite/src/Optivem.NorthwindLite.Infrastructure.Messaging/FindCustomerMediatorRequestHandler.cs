using Optivem.Core.Application;
using Optivem.Infrastructure.Messaging.MediatR;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;

namespace Optivem.NorthwindLite.Infrastructure.Messaging
{
    public class FindCustomerMediatorRequestHandler : MediatorRequestHandler<FindCustomerRequest, FindCustomerResponse>
    {
        public FindCustomerMediatorRequestHandler(IUseCase<FindCustomerRequest, FindCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
