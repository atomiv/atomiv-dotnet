using Optivem.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class BrowseOrdersQueryResponse
    {
        public List<BrowseOrdersRecordQueryResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class BrowseOrdersRecordQueryResponse
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal TotalPrice { get; set; }
    }
}