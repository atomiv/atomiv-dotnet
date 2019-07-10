using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Services;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;

namespace Optivem.Template.Core.Application.Orders.Services
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

    // TODO: VC: Introduce subclasses of orders, e.g. express and regular orders? sales order vs purchase order
    // TODO: VC: Also then show inheritance both in domain and in DB
}
