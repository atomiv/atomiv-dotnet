using Atomiv.Template.Core.Common.Orders;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Queries.Orders
{
    public class ViewOrderQueryResponse
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public List<FindOrderItemQueryResponse> OrderItems { get; set; }
    }

    public class FindOrderItemQueryResponse
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public OrderItemStatus Status { get; set; }
    }
}