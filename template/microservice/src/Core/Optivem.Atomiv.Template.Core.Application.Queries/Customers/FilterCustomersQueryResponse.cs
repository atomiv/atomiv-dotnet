using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Template.Core.Application.Queries.Customers
{
    public class FilterCustomersQueryResponse
    {
        public List<ListCustomersRecordResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class ListCustomersRecordResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}