using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class CreateProductCommandResponse
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsListed { get; set; }
    }
}
