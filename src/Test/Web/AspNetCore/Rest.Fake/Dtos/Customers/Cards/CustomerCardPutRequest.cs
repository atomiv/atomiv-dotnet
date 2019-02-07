using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Dtos.Customers.Cards
{
    public class CustomerCardPutRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}
