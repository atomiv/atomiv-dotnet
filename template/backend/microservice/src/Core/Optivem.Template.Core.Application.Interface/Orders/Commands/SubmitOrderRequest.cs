using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class SubmitOrderRequest : IRequest<OrderResponse>
    {
        public Guid Id { get; set; }
    }
}