using Atomiv.Core.Application;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class EditOrderCommand : IRequest<EditOrderCommandResponse>
    {
        public string Id { get; set; }

        public List<EditOrderItemCommand> OrderItems { get; set; }
    }

    public class EditOrderItemCommand
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}