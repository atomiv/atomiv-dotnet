using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class FindOrderQuery : IRequest<FindOrderQueryResponse>
    {
        public Guid Id { get; set; }
    }
}