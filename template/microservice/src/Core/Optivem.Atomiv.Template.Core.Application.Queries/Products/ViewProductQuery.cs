using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Queries.Products
{
    public class ViewProductQuery : IRequest<ViewProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}