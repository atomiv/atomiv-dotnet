using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class RelistProductCommand : IRequest<RelistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}