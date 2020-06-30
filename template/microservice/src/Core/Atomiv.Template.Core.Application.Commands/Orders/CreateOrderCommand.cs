using Atomiv.Core.Application;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        public string CustomerId { get; set; }

        public List<CreateOrderItemCommand> OrderItems { get; set; }
    }

    public class CreateOrderItemCommand
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}