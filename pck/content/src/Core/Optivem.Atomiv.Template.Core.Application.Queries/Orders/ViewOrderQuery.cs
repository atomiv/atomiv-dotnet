using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Queries.Orders
{
    public class ViewOrderQuery : IRequest<ViewOrderQueryResponse>
    {
        public Guid Id { get; set; }
    }
}