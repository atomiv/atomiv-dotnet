using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Responses;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class CreateProductRequest : IRequest<ProductResponse>
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}