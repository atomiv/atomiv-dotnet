using Optivem.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItemResponse> OrderItems { get; set; }
    }

    public class OrderItemResponse
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        public OrderItemStatus Status { get; set; }
    }
}
