using Optivem.Framework.Core.Common;
using System;

namespace Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers
{
    public class CustomerPutResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}