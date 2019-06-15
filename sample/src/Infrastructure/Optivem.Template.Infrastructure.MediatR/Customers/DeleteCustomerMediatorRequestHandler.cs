using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    public class DeleteCustomerMediatorRequestHandler : MediatorRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        public DeleteCustomerMediatorRequestHandler(IUseCase<DeleteCustomerRequest, DeleteCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
