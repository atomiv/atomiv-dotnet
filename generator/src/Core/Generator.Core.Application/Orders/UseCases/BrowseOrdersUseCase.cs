using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Generator.Core.Application.Orders.Requests;
using Generator.Core.Application.Orders.Responses;
using Generator.Core.Domain.Orders;

namespace Generator.Core.Application.Orders.UseCases
{
    public class BrowseOrdersUseCase : BrowseAggregatesUseCase<IOrderRepository, BrowseOrdersRequest, BrowseOrdersResponse, BrowseOrdersRecordResponse, Order, OrderIdentity, int>
    {
        public BrowseOrdersUseCase(IUseCaseMapper mapper, IOrderRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}
