using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Queries.Customers
{
    public class FilterCustomersQueryResponse
    {
        public List<ListCustomersRecordResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class ListCustomersRecordResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}