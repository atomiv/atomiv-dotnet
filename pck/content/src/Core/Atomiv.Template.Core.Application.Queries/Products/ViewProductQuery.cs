using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Queries.Products
{
    public class ViewProductQuery : IRequest<ViewProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}