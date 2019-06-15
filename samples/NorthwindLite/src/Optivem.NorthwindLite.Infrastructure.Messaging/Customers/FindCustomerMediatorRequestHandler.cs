using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;

namespace Optivem.NorthwindLite.Infrastructure.MediatR.Customers
{
    public class FindCustomerMediatorRequestHandler : MediatorRequestHandler<FindCustomerRequest, FindCustomerResponse>
    {
        public FindCustomerMediatorRequestHandler(IUseCase<FindCustomerRequest, FindCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}