using System;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers.Cards
{
    public class CustomerCardPutRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}