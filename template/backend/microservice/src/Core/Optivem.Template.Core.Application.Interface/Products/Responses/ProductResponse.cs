using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsListed { get; set; }
    }
}
