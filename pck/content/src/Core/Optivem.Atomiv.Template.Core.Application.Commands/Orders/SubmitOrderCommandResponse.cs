using Optivem.Atomiv.Template.Core.Common.Orders;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Orders
{
    public class SubmitOrderCommandResponse
    {
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }
    }
}
