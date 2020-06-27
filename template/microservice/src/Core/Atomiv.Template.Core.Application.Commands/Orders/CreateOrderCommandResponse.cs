using Atomiv.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class CreateOrderCommandResponse
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public List<CreateOrderItemResponse> OrderItems { get; set; }
    }

    public class CreateOrderItemResponse
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public decimal Quantity { get; set; }

        public OrderItemStatus Status { get; set; }
    }
}
