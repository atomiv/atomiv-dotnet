using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class FindProductRequest : IRequest<FindProductResponse>
    {
        public Guid Id { get; set; }
    }
}