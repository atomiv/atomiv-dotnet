using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class CancelOrderCommand : ICommand<CancelOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}