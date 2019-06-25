using Optivem.Core.Application;
using System;

namespace Optivem.Web.AspNetCore.Fake.Dtos.Customers
{
    public class CustomerPostResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}