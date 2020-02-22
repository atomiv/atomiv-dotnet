using System;

namespace Optivem.Atomiv.Template.Core.Application.Products.Queries
{
    public class ViewProductQueryResponse
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsListed { get; set; }
    }
}