using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class FindOrderResponse
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public byte StatusId { get; set; }

        public List<FindOrderItemResponse> OrderItems { get; set; }
    }

    public class FindOrderItemResponse
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        public byte StatusId { get; set; }
    }
}