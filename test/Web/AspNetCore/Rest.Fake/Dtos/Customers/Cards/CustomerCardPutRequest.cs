using System;

namespace Optivem.Framework.Web.AspNetCore.Rest.Fake.Dtos.Customers.Cards
{
    public class CustomerCardPutRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}
