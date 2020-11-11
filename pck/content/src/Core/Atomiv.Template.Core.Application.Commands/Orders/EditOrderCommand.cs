using Atomiv.Core.Application;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class EditOrderCommand : ICommand<EditOrderCommandResponse>
    {
        public Guid Id { get; set; }

        public List<EditOrderItemCommand> OrderItems { get; set; }
    }

    public class EditOrderItemCommand
    {
        public Guid? Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}