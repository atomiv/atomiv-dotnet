using Optivem.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers
{
    public class CustomerGetSubsetResponse : ICollectionResponse<CustomerGetSubsetRecordResponse, int>
    {
        public List<CustomerGetSubsetRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public class CustomerGetSubsetRecordResponse : IResponse<int>
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