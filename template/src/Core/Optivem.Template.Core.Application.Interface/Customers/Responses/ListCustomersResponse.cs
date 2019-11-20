using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Customers.Responses
{
    public class ListCustomersResponse : ICollectionResponse<ListCustomersRecordResponse, int>
    {
        public List<ListCustomersRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListCustomersRecordResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}