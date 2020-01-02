using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}