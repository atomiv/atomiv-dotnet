using Atomiv.Core.Domain;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderItem : Entity<OrderItemIdentity>, IReadonlyOrderItem
    {
        private ProductIdentity _productId;
        private decimal _unitPrice;
        private int _quantity;
        private OrderItemStatus _status;

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

        public ProductIdentity ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                if(value == null)
                {
                    throw new DomainException("Product Id cannot be null");
                }

                _productId = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                if(value < 0)
                {
                    throw new DomainException("Unit price cannot be negative");
                }

                _unitPrice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if(value <= 0)
                {
                    throw new DomainException("Quantity cannot be less than zero");
                }

                _quantity = value;
            }
        }

        public OrderItemStatus Status
        {
            get
            {
                return _status;
            }
            private set
            {
                if(value == OrderItemStatus.None)
                {
                    throw new DomainException("Order item status must be defined");
                }

                _status = value;
            }
        }

        public void Allocate()
        {
            Status = OrderItemStatus.Allocated;
        }

        public void CannotFulfill()
        {
            Status = OrderItemStatus.Unavailable;
        }
    }
}