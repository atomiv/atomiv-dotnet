using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class RelistProductCommand : IRequest<RelistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}