using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class ArchiveOrderRequest : IRequest<OrderResponse>
    {
        public Guid Id { get; set; }
    }
}