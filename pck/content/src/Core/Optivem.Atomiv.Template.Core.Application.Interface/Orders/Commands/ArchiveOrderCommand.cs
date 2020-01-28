using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Commands
{
    public class ArchiveOrderCommand : IRequest<ArchiveOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}