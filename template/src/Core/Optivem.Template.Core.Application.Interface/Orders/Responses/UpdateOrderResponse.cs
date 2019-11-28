using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class UpdateOrderResponse
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public byte StatusId { get; set; }

        public List<UpdateOrderItemResponse> OrderItems { get; set; }
    }

    public class UpdateOrderItemResponse
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        public byte StatusId { get; set; }
    }
}