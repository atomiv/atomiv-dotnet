using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class ArchiveOrderRequest : IRequest<ArchiveOrderResponse>
    {
        public Guid Id { get; set; }
    }
}