using Optivem.Framework.Core.Application;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders.Entities;
using Optivem.Generator.Core.Domain.Orders.Repositories;
using Optivem.Generator.Core.Domain.Orders.ValueObjects;

namespace Optivem.Generator.Core.Application.Orders.UseCases
{
    public class BrowseOrdersUseCase : BrowseAggregatesUseCase<IOrderRepository, BrowseOrdersRequest, BrowseOrdersResponse, BrowseOrdersRecordResponse, Order, OrderIdentity, int>
    {
        public BrowseOrdersUseCase(IOrderRepository repository, ICollectionResponseMapper<Order, BrowseOrdersResponse> responseMapper) : base(repository, responseMapper)
        {
        }
    }
}
