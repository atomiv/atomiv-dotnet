using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UpdateProductCommandResponse
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsListed { get; set; }
    }
}
