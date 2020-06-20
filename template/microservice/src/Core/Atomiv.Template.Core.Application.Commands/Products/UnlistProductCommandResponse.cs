using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class UnlistProductCommandResponse
    {
        public Guid Id { get; set; }

        public bool IsListed { get; set; }
    }
}
