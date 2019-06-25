using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Products
{
    public class UpdateProductRequest : IRequest<int>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
