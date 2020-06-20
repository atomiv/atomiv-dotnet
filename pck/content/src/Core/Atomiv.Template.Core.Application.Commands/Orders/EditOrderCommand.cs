using Atomiv.Core.Application;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class EditOrderCommand : IRequest<EditOrderCommandResponse>
    {
        public Guid Id { get; set; }

        public List<UpdateOrderItemCommand> OrderItems { get; set; }
    }

    public class UpdateOrderItemCommand
    {
        public Guid? Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}