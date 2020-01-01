using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class SubmitOrderRequest : IRequest<SubmitOrderResponse>
    {
        public Guid Id { get; set; }
    }
}