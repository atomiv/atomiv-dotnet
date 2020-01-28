using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Products.Commands
{
    public class UnlistProductCommand : IRequest<UnlistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}