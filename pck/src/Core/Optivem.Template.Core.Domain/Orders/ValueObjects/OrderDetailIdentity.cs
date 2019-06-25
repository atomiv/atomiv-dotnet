using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Orders.ValueObjects
{
    public class OrderDetailIdentity : Identity<int>
    {
        public OrderDetailIdentity(int id)
            : base(id)
        {
        }
    }
}
