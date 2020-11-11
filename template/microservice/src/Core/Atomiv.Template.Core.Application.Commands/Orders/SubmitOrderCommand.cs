using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class SubmitOrderCommand : ICommand<SubmitOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}