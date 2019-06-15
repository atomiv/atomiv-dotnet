using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    // TODO: VC: Auto-generate these handlers

    public class CreateCustomerMediatorRequestHandler : MediatorRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public CreateCustomerMediatorRequestHandler(IUseCase<CreateCustomerRequest, CreateCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}