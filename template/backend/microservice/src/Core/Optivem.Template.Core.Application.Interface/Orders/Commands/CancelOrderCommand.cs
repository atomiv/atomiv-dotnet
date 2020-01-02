using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class CancelOrderCommand : IRequest<CancelOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}