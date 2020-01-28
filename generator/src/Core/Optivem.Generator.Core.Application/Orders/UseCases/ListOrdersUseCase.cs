using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Mappers;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders;

namespace Optivem.Generator.Core.Application.Orders.UseCases
{
    public class ListOrdersUseCase : ListAggregatesUseCase<IOrderRepository, ListOrdersRequest, ListOrdersResponse, ListOrdersRecordResponse, Order, OrderIdentity, int>
    {
        public ListOrdersUseCase(IUseCaseMapper mapper, IOrderRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}
