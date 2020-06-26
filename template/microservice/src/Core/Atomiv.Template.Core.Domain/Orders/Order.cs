using Atomiv.Core.Domain;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class Order : Entity<OrderIdentity>
    {
        private CustomerIdentity _customerId;
        private List<OrderItem> _orderItems;
        private OrderStatus _orderStatus;

        public Order(OrderIdentity id, CustomerIdentity customerId, DateTime orderDate, OrderStatus status, IEnumerable<IReadonlyOrderItem> orderItems)
            : base(id)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            Status = status;
            OrderItems = orderItems.ToList().AsReadOnly();
        }

        public CustomerIdentity CustomerId
        {
            get
            {
                return _customerId;
            }
            private set
            {
                if (value == null)
                {
                    throw new DomainException("Customer id cannot be null");
                }

                _customerId = value;
            }
        }

        public DateTime OrderDate { get; }

        public OrderStatus Status
        {
            get
            {
                return _orderStatus;
            }
            set
            {
                if(value == OrderStatus.None)
                {
                    throw new DomainException("Order status cannot be none");
                }

                _orderStatus = value;
            }
        }

        public IEnumerable<IReadonlyOrderItem> OrderItems
        {
            get
            {
                return _orderItems
                    .Cast<IReadonlyOrderItem>()
                    .ToList();
            }
            set
            {
                if (value == null)
                {
                    throw new DomainException("Order items cannot be null");
                }

                _orderItems = value.Select(e => new OrderItem(e)).ToList();
            }
        }

        public void AddOrderItem(IReadonlyOrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new DomainException("Order item cannot be null");
            }

            if(_orderItems.Any(e => e.Id == orderItem.Id))
            {
                throw new DomainException($"Cannot add order item because order item id {orderItem.Id} already exists in the order");
            }

            _orderItems.Add(new OrderItem(orderItem));
        }

        public void RemoveOrderItem(OrderItemIdentity orderItemId)
        {
            if(orderItemId == null)
            {
                throw new DomainException("Order item id cannot be null");
            }

            var orderItem = _orderItems.FirstOrDefault(e => e.Id == orderItemId);

            if (orderItem == null)
            {
                throw new DomainException($"Order detail {orderItemId} does not exist in the order");
            }

            _orderItems.Remove(orderItem);
        }

        public void UpdateOrderItem(OrderItemIdentity orderItemId, ProductIdentity productId, decimal unitPrice, int quantity)
        {
            if(orderItemId == null)
            {
                throw new DomainException("Order item id cannot be null");
            }

            var orderItem = _orderItems.FirstOrDefault(e => e.Id == orderItemId);

            if (orderItem == null)
            {
                throw new DomainException($"Order item {orderItemId} does not exist in the order");
            }

            orderItem.ProductId = productId;
            orderItem.UnitPrice = unitPrice;
            orderItem.Quantity = quantity;
        }

        public void Submit()
        {
            if(Status != OrderStatus.Draft)
            {
                throw new DomainException($"Order in status {Status} cannot be submitted");
            }

            Status = OrderStatus.Submitted;
        }

        public void Ship()
        {
            if(Status != OrderStatus.Submitted)
            {
                throw new DomainException($"Order in status {Status} cannot be shipped");
            }

            Status = OrderStatus.Shipped;
        }

        public void Cancel()
        {
            if(Status != OrderStatus.Draft && Status != OrderStatus.Submitted)
            {
                throw new DomainException($"Order in status {Status} cannot be cancelled");
            }

            Status = OrderStatus.Cancelled;
        }
    }
}