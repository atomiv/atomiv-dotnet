using System;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.Fake.Dtos.Customers
{
    public class CustomerGetAllResponse
    {
        public List<CustomerGetAllRecordResponse> Results { get; set; }
    }

    public class CustomerGetAllRecordResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int CardCount { get; set; }
    }
}