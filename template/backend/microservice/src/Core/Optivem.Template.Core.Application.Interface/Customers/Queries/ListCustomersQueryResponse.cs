using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class ListCustomersQueryResponse
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