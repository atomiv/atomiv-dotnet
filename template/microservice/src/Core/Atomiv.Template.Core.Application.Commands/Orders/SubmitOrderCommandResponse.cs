using Atomiv.Template.Core.Common.Orders;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class SubmitOrderCommandResponse
    {
        public string Id { get; set; }

        public OrderStatus Status { get; set; }
    }
}
