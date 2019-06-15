using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;

namespace Optivem.NorthwindLite.Infrastructure.MediatR.Customers
{
    // TODO: VC: Auto-generate these handlers

    public class CreateCustomerMediatorRequestHandler : MediatorRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public CreateCustomerMediatorRequestHandler(IUseCase<CreateCustomerRequest, CreateCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}