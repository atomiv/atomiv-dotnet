using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdentityGenerator : IIdentityGenerator<OrderIdentity>
    {
        public OrderIdentity Next()
        {
            return new OrderIdentity(Guid.NewGuid());
        }
    }
}
