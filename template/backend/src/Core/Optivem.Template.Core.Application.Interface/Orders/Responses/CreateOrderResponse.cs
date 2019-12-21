using Optivem.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class CreateOrderResponse
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public List<CreateOrderItemResponse> OrderItems { get; set; }
    }

    public class CreateOrderItemResponse
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        public OrderItemStatus Status { get; set; }
    }
}