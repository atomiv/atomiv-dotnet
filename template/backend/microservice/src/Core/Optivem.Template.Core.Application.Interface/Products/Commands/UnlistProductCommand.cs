using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UnlistProductCommand : IRequest<UnlistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}