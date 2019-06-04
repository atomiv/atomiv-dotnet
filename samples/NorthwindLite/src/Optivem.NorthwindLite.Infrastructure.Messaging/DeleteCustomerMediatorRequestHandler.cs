using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;

namespace Optivem.NorthwindLite.Infrastructure.Messaging
{
    public class DeleteCustomerMediatorRequestHandler : MediatorRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        public DeleteCustomerMediatorRequestHandler(IUseCase<DeleteCustomerRequest, DeleteCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
