using System.Threading.Tasks;
using Atomiv.Core.Application;
using Atomiv.Core.Application.Services;
using Generator.Core.Application.Orders.Requests;
using Generator.Core.Application.Orders.Responses;

namespace Generator.Core.Application.Orders
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<ArchiveOrderResponse> ArchiveOrderAsync(ArchiveOrderRequest request)
        {
            return HandleAsync<ArchiveOrderRequest, ArchiveOrderResponse>(request);
        }

        public Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            return HandleAsync<BrowseOrdersRequest, BrowseOrdersResponse>(request);
        }

        public Task<CancelOrderResponse> CancelOrderAsync(CancelOrderRequest request)
        {
            return HandleAsync<CancelOrderRequest, CancelOrderResponse>(request);
        }

        public Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            return HandleAsync<CreateOrderRequest, CreateOrderResponse>(request);
        }

        public Task<FindOrderResponse> FindOrderAsync(FindOrderRequest request)
        {
            return HandleAsync<FindOrderRequest, FindOrderResponse> (request);
        }

        public Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request)
        {
            return HandleAsync<ListOrdersRequest, ListOrdersResponse>(request);
        }

        public Task<SubmitOrderResponse> SubmitOrderAsync(SubmitOrderRequest request)
        {
            return HandleAsync<SubmitOrderRequest, SubmitOrderResponse> (request);
        }

        public Task<UpdateOrderResponse> UpdateOrderAsync(UpdateOrderRequest request)
        {
            return HandleAsync<UpdateOrderRequest, UpdateOrderResponse> (request);
        }
    }
}
