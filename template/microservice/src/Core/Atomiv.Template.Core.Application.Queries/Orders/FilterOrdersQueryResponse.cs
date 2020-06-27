using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Queries.Orders
{
    public class FilterOrdersQueryResponse
    {
        public List<ListOrdersRecordQueryResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class ListOrdersRecordQueryResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}