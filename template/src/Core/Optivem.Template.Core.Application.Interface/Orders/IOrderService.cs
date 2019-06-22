using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Orders
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
