using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List
{
    public class ListCustomersResponse : IListResponse<ListCustomersElementResponse, int>
    {
        public List<ListCustomersElementResponse> Data { get; set; }
    }

    public class ListCustomersElementResponse : IListElementResponse<int>
    {
        public int Id { get; set; }
    }
}
