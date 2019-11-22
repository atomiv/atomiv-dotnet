using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdNameReadModel : IdNameReadModel<int>
    {
        public OrderIdNameReadModel(int id, string name) : base(id, name)
        {
        }
    }
}
