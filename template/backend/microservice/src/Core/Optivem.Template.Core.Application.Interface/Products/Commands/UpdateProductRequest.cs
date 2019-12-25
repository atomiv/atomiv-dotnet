using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UpdateProductRequest : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}