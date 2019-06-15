using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;

namespace Optivem.NorthwindLite.Infrastructure.MediatR.Customers
{
    public class DeleteCustomerMediatorRequestHandler : MediatorRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        public DeleteCustomerMediatorRequestHandler(IUseCase<DeleteCustomerRequest, DeleteCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
