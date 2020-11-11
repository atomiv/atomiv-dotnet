using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class UnlistProductCommand : ICommand<UnlistProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}