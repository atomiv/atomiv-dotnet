using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public class OrderApplicationService : ApplicationService, IOrderApplicationService
    {
        public OrderApplicationService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<OrderResponse> ArchiveOrderAsync(Guid id)
        {
            var request = new ArchiveOrderRequest
            {
                Id = id,
            };

            return HandleAsync<ArchiveOrderRequest, OrderResponse>(request);
        }

        public Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            return HandleAsync<BrowseOrdersRequest, BrowseOrdersResponse>(request);
        }

        public Task<OrderResponse> CancelOrderAsync(Guid id)
        {
            var request = new CancelOrderRequest
            {
                Id = id,
            };

            return HandleAsync<CancelOrderRequest, OrderResponse>(request);
        }

        public Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            return HandleAsync<CreateOrderRequest, OrderResponse>(request);
        }

        public Task<FindOrderResponse> FindOrderAsync(Guid id)
        {
            var request = new FindOrderRequest
            {
                Id = id,
            };

            return HandleAsync<FindOrderRequest, FindOrderResponse>(request);
        }

        public Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request)
        {
            return HandleAsync<ListOrdersRequest, ListOrdersResponse>(request);
        }

        public Task<OrderResponse> SubmitOrderAsync(Guid id)
        {
            var request = new SubmitOrderRequest
            {
                Id = id,
            };

            return HandleAsync<SubmitOrderRequest, OrderResponse>(request);
        }

        public Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest request)
        {
            return HandleAsync<UpdateOrderRequest, OrderResponse>(request);
        }
    }
}