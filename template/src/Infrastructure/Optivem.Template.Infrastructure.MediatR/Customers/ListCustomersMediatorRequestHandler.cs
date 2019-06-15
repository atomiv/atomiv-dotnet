using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    public class ListCustomersMediatorRequestHandler : MediatorRequestHandler<ListCustomersRequest, ListCustomersResponse>
    {
        public ListCustomersMediatorRequestHandler(IUseCase<ListCustomersRequest, ListCustomersResponse> useCase)
            : base(useCase)
        {
        }
    }
}