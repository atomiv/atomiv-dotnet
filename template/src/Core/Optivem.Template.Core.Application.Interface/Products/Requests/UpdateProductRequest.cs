using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Responses;
using System;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}