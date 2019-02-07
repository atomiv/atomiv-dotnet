using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Entities
{
    public class Card
    {
        public string Number { get; set; }

        public CardExpiration Expiration { get; set; }
    }
}
