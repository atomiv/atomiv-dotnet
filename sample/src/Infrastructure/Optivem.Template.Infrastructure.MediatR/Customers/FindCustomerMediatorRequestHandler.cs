using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    public class FindCustomerMediatorRequestHandler : MediatorRequestHandler<FindCustomerRequest, FindCustomerResponse>
    {
        public FindCustomerMediatorRequestHandler(IUseCase<FindCustomerRequest, FindCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}