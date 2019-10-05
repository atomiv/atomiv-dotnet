using Optivem.Framework.Core.Common;

namespace Optivem.Template.Core.Application.Products.Responses
{
    public class UpdateProductResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
