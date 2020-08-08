using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Queries.Products
{
    public class ViewProductQuery : IQuery<ViewProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}