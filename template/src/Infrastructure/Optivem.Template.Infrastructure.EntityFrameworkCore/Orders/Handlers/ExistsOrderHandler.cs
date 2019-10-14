using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders.Handlers
{
    public class ExistsOrderHandler : ExistsAggregateRootHandler<DatabaseContext, Order, OrderIdentity, OrderRecord, int>
    {
        public ExistsOrderHandler(DatabaseContext context) : base(context)
        {
        }
    }
}
