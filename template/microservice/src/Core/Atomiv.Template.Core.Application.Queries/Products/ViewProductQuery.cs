using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Queries.Products
{
    public class ViewProductQuery : IRequest<ViewProductQueryResponse>
    {
        public string Id { get; set; }
    }
}