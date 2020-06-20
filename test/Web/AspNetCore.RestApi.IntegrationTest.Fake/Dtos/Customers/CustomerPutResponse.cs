using System;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers
{
    public class CustomerPutResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}