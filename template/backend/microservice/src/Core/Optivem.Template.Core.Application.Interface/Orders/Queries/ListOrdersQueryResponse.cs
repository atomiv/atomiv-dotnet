using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class ListOrdersQueryResponse
    {
        public List<ListOrdersRecordQueryResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListOrdersRecordQueryResponse
    {
        public Guid Id { get; set; }
    }
}