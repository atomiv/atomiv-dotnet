using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Customers.Responses
{
    public class BrowseCustomersResponse
    {
        public List<BrowseCustomersRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class BrowseCustomersRecordResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}