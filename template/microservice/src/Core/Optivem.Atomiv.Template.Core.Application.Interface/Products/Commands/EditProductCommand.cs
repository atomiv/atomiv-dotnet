using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Products.Commands
{
    public class EditProductCommand : IRequest<EditProductCommandResponse>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}