using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Products.Queries
{
    public class ViewProductQuery : IRequest<ViewProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}