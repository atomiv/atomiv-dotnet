using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Common.Orders;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Template.Core.Domain.Orders
{
    public interface IReadonlyOrderItem : IReadonlyEntity<OrderItemIdentity>
    {
        ProductIdentity ProductId { get; }

        int Quantity { get; }

        decimal UnitPrice { get; }

        OrderItemStatus Status { get; }
    }
}
