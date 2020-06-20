using Atomiv.Core.Application;
using System.Collections.Generic;

namespace Generator.Core.Application.Customers.Responses
{
    public class ListCustomersResponse : ICollectionResponse<ListCustomersRecordResponse, int>
    {
        public List<ListCustomersRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public class ListCustomersRecordResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}