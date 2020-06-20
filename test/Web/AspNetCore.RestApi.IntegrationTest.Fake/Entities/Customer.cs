using System;
using System.Collections.Generic;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public List<Card> Cards { get; set; }
    }
}