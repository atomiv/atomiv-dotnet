using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class UnlistProductCommand : IRequest<UnlistProductCommandResponse>
    {
        public string Id { get; set; }
    }
}