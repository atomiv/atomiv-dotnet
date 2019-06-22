using Optivem.Core.Application;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Customers
{
    public class ListCustomersResponse : ICollectionResponse<ListCustomersElementResponse, int>
    {
        public List<ListCustomersElementResponse> Data { get; set; }
    }

    public class ListCustomersElementResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}