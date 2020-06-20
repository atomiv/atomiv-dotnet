using Atomiv.Core.Domain;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Core.Domain.Orders
{
    public interface IReadonlyOrderItem : IReadonlyEntity<OrderItemIdentity>
    {
        ProductIdentity ProductId { get; }

        int Quantity { get; }

        decimal UnitPrice { get; }

        OrderItemStatus Status { get; }
    }
}
