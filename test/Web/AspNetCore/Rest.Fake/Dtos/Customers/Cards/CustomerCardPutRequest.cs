using System;

namespace Optivem.Platform.Web.AspNetCore.Rest.Fake.Dtos.Customers.Cards
{
    public class CustomerCardPutRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}
