using Atomiv.Core.Domain;
using Generator.Core.Domain.Products;

namespace Generator.Core.Domain.Orders
{
    public class OrderDetail : Entity<OrderDetailIdentity>
    {
        public OrderDetail(OrderDetailIdentity id, ProductIdentity productId, decimal quantity, decimal unitPrice, OrderDetailStatus status) 
            : base(id)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Status = status;
        }

        public ProductIdentity ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public OrderDetailStatus Status { get; }
    }
}