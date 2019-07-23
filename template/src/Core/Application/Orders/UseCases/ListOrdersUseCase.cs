using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders.Entities;
using Optivem.Template.Core.Domain.Orders.Repositories;
using Optivem.Template.Core.Domain.Orders.ValueObjects;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class ListOrdersUseCase : ListAggregatesUseCase<IOrderRepository, ListOrdersRequest, ListOrdersResponse, ListOrdersRecordResponse, Order, OrderIdentity, int>
    {
        public ListOrdersUseCase(IOrderRepository repository, ICollectionResponseMapper<Order, ListOrdersResponse> responseMapper) : base(repository, responseMapper)
        {
        }
    }
}
