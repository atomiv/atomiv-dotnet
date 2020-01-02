using Optivem.Framework.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        public Guid CustomerId { get; set; }

        public List<CreateOrderItemCommand> OrderItems { get; set; }
    }

    public class CreateOrderItemCommand
    {
        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}