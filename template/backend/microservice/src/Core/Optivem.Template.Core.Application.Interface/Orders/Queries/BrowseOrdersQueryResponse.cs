using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class BrowseOrdersQueryResponse
    {
        public List<BrowseOrdersRecordQueryResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class BrowseOrdersRecordQueryResponse
    {
        public Guid Id { get; set; }
    }
}