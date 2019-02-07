using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Dtos
{
    public class CustomerCardPostRequest
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationYear { get; set; }
    }
}
