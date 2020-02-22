using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Common.Orders;
using Optivem.Atomiv.Template.Core.Domain.Products;

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
