using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Domain.Orders
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

        public ProductIdentity ProductId { get; private set; }

        public decimal UnitPrice { get; private set; }

        public void SetProduct(Product product)
        {
            ProductId = product.Id;
            UnitPrice = product.ListPrice;
        }

        public decimal Quantity { get; set; }

        public OrderDetailStatus Status { get; }
    }
}