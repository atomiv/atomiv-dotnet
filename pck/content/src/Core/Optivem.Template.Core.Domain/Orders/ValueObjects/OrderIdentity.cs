using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Orders.ValueObjects
{
    public class OrderIdentity : Identity<int>
    {
        public OrderIdentity(int id) : base(id)
        {
        }
    }
}
