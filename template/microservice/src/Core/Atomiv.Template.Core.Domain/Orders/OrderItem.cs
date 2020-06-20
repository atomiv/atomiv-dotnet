using Atomiv.Core.Domain;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderItem : Entity<OrderItemIdentity>, IReadonlyOrderItem
    {
        public OrderItem(OrderItemIdentity id, ProductIdentity productId, decimal unitPrice, int quantity, OrderItemStatus status)
            : base(id)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Status = status;
        }

        public OrderItem(IReadonlyOrderItem orderItem)
            : this(orderItem.Id, orderItem.ProductId, orderItem.UnitPrice, orderItem.Quantity, orderItem.Status)
        {

        }

        public ProductIdentity ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public OrderItemStatus Status { get; }
    }
}