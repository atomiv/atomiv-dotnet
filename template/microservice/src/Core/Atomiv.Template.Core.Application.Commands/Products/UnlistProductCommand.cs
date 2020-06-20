using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class UnlistProductCommand : IRequest<UnlistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}