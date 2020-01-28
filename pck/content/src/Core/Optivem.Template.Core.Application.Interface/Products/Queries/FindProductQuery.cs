using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class FindProductQuery : IRequest<FindProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}