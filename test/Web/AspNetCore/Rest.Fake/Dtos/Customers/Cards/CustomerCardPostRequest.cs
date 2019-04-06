using System;

namespace Optivem.Platform.Web.AspNetCore.Rest.Fake.Dtos
{
    public class CustomerCardPostRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}
