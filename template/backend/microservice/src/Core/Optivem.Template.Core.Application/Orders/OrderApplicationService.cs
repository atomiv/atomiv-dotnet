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

        public Task<ArchiveOrderResponse> ArchiveOrderAsync(ArchiveOrderRequest request)
        {
            return HandleAsync(request);
        }

        public Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            return HandleAsync(request);
        }

        public Task<CancelOrderResponse> CancelOrderAsync(CancelOrderRequest request)
        {
            return HandleAsync(request);
        }

        public Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            return HandleAsync(request);
        }

        public Task<FindOrderResponse> FindOrderAsync(FindOrderRequest request)
        {
            return HandleAsync(request);
        }

        public Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request)
        {
            return HandleAsync(request);
        }

        public Task<SubmitOrderResponse> SubmitOrderAsync(SubmitOrderRequest request)
        {
            return HandleAsync(request);
        }

        public Task<UpdateOrderResponse> UpdateOrderAsync(UpdateOrderRequest request)
        {
            return HandleAsync(request);
        }
    }
}