using Optivem.Framework.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class FindOrderQuery : IRequest<FindOrderQueryResponse>
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public List<FindOrderItemQuery> OrderItems { get; set; }
    }

    public class FindOrderItemQuery
    {
        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}