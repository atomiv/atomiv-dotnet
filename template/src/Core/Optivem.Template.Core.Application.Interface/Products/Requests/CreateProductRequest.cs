using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Products
{
    public class CreateProductRequest : IRequest
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
