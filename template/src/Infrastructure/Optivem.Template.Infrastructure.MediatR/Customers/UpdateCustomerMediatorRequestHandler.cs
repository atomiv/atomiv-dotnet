using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    public class UpdateCustomerMediatorRequestHandler : MediatorRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public UpdateCustomerMediatorRequestHandler(IUseCase<UpdateCustomerRequest, UpdateCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
