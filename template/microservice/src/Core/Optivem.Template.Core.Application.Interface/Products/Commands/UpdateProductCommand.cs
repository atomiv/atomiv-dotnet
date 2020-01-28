using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}