using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class CancelOrderRequest : IRequest<CancelOrderResponse>
    {
        public Guid Id { get; set; }
    }
}