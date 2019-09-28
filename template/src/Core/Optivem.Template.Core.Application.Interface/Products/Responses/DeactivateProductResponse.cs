using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Products.Responses
{
    public class DeactivateProductResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
