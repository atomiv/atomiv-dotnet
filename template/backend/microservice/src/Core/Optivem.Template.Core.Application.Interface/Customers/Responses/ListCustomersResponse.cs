using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Customers.Responses
{
    public class ListCustomersResponse
    {
        public List<ListCustomersRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListCustomersRecordResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}