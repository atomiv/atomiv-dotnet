using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Template.Core.Application.Queries.Orders
{
    public class FilterOrdersQueryResponse
    {
        public List<ListOrdersRecordQueryResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class ListOrdersRecordQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}