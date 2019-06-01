using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;

namespace Optivem.NorthwindLite.Infrastructure.Messaging
{
    // TODO: VC: Auto-generate these handlers

    public class CreateCustomerMediatorRequestHandler : MediatorRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public CreateCustomerMediatorRequestHandler(IUseCase<CreateCustomerRequest, CreateCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}