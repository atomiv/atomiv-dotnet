using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public class OrderService : ApplicationService, IOrderService
    {
        public OrderService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<OrderResponse> ArchiveOrderAsync(ArchiveOrderRequest request)
        {
            return HandleAsync<ArchiveOrderRequest, OrderResponse>(request);
        }

        public Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            return HandleAsync<BrowseOrdersRequest, BrowseOrdersResponse>(request);
        }

        public Task<OrderResponse> CancelOrderAsync(CancelOrderRequest request)
        {
            return HandleAsync<CancelOrderRequest, OrderResponse>(request);
        }

        public Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            return HandleAsync<CreateOrderRequest, OrderResponse>(request);
        }

        public Task<FindOrderResponse> FindOrderAsync(FindOrderRequest request)
        {
            return HandleAsync<FindOrderRequest, FindOrderResponse>(request);
        }

        public Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request)
        {
            return HandleAsync<ListOrdersRequest, ListOrdersResponse>(request);
        }

        public Task<OrderResponse> SubmitOrderAsync(SubmitOrderRequest request)
        {
            return HandleAsync<SubmitOrderRequest, OrderResponse>(request);
        }

        public Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest request)
        {
            return HandleAsync<UpdateOrderRequest, OrderResponse>(request);
        }
    }
}