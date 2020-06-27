using Atomiv.Template.Core.Common.Orders;
using System;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class CancelOrderCommandResponse
    {
        public string Id { get; set; }

        public OrderStatus Status { get; set; }
    }
}
