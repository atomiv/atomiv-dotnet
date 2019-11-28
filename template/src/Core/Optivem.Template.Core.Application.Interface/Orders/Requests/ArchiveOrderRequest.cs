using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;
using System;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class ArchiveOrderRequest : IRequest<ArchiveOrderResponse>
    {
        public Guid Id { get; set; }
    }
}