using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Products
{
    public class RelistProductCommand : IRequest<RelistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}