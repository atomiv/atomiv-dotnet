using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Products
{
    public class UnlistProductCommand : IRequest<UnlistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}