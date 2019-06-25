using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;

namespace Optivem.Template.Core.Application.Orders.Services
{
    public interface IOrderService
    {
        ArchiveOrderResponse ArchiveOrder(ArchiveOrderRequest request);

        BrowseOrdersResponse BrowseOrders(BrowseOrdersRequest request);

        CancelOrderResponse CancelOrder(CancelOrderRequest request);

        CreateOrderResponse CreateOrder(CreateOrderRequest request);

        FindOrderResponse FindOrder(FindOrderRequest request);

        ListOrdersResponse ListOrders(ListOrdersRequest request);

        SubmitOrderResponse SubmitOrder(SubmitOrderRequest request);

        UpdateOrderResponse UpdateOrder(UpdateOrderRequest request);
    }
}
