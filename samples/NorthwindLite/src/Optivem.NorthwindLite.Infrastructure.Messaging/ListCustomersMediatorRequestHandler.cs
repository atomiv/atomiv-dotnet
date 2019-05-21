using Optivem.Core.Application;
using Optivem.Infrastructure.Messaging.MediatR;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.BrowseAll;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;

namespace Optivem.NorthwindLite.Infrastructure.Messaging
{
    public class ListCustomersMediatorRequestHandler : MediatorRequestHandler<ListCustomersRequest, ListCustomersResponse>
    {
        public ListCustomersMediatorRequestHandler(IUseCase<ListCustomersRequest, ListCustomersResponse> useCase)
            : base(useCase)
        {
        }
    }
}