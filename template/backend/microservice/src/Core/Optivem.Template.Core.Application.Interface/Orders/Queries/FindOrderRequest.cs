using Optivem.Framework.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class FindOrderRequest : IRequest<FindOrderResponse>
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public List<FindOrderItemRequest> OrderItems { get; set; }
    }

    public class FindOrderItemRequest
    {
        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}