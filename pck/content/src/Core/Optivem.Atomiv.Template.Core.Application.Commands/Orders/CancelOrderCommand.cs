using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Orders
{
    public class CancelOrderCommand : IRequest<CancelOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}