using System;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos
{
    public class CustomerCardPostRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}