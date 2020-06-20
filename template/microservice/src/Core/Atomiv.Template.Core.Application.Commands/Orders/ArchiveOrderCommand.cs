using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class ArchiveOrderCommand : IRequest<ArchiveOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}