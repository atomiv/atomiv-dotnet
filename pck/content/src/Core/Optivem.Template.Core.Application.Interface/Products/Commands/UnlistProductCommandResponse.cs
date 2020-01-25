using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UnlistProductCommandResponse
    {
        public Guid Id { get; set; }

        public bool IsListed { get; set; }
    }
}
