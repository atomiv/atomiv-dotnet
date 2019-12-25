using Optivem.Framework.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class UpdateOrderRequest : IRequest<OrderResponse>
    {
        public Guid Id { get; set; }

        public List<UpdateOrderItemRequest> OrderItems { get; set; }
    }

    public class UpdateOrderItemRequest
    {
        public Guid? Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}