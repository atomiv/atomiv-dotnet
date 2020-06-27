using Atomiv.Template.Core.Common.Orders;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class EditOrderCommandResponse
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public List<UpdateOrderItemCommandResponse> OrderItems { get; set; }
    }

    public class UpdateOrderItemCommandResponse
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public decimal Quantity { get; set; }

        public OrderItemStatus Status { get; set; }
    }
}
