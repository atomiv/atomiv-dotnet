using Optivem.Atomiv.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Queries
{
    public class FindOrderQueryResponse
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public List<FindOrderItemQueryResponse> OrderItems { get; set; }
    }

    public class FindOrderItemQueryResponse
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public OrderItemStatus Status { get; set; }
    }
}