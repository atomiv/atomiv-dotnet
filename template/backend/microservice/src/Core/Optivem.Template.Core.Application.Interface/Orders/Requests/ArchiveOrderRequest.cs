using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Responses;
using System;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class ArchiveOrderRequest : IRequest<OrderResponse>
    {
        public Guid Id { get; set; }
    }
}