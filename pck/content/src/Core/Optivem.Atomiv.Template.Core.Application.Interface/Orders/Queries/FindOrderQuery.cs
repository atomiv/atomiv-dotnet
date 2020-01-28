using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Queries
{
    public class FindOrderQuery : IRequest<FindOrderQueryResponse>
    {
        public Guid Id { get; set; }
    }
}