using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Responses;
using System;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class CancelOrderRequest : IRequest<CancelOrderResponse>
    {
        public Guid Id { get; set; }
    }
}