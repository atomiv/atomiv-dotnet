using Optivem.Atomiv.Core.Domain;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Template.Core.Domain.Orders
{
    public class Order : Entity<OrderIdentity>
    {
        private CustomerIdentity _customerId;
        private List<OrderItem> _orderItems;

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
            get { return _customerId; }
            private set
            {
                _customerId = value ?? throw new ArgumentNullException();
            }
        }

        public DateTime? OrderDate { get; }

        public OrderStatus Status { get; private set; }

        public ReadOnlyCollection<IReadonlyOrderItem> OrderItems
        {
            get
            {
                return _orderItems
                    .Cast<IReadonlyOrderItem>()
                    .ToList()
                    .AsReadOnly(); }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (!value.Any())
                {
                    throw new ArgumentException("There are no order items");
                }

                _orderItems = value.Select(e => new OrderItem(e)).ToList();
            }
        }



        public void AddOrderItem(IReadonlyOrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException();
            }

            if(_orderItems.Any(e => e.Id == orderItem.Id))
            {
                throw new ArgumentException($"Cannot add order item because order item id {orderItem.Id} already exists in the order");
            }

            _orderItems.Add(new OrderItem(orderItem));
        }

        public void RemoveOrderItem(OrderItemIdentity orderItemId)
        {
            var orderItem = _orderItems.FirstOrDefault(e => e.Id == orderItemId);

            if (orderItem == null)
            {
                throw new ArgumentException($"Order detail {orderItemId} does not exist in the order");
            }

            _orderItems.Remove(orderItem);
        }

        public void UpdateOrderItem(OrderItemIdentity orderItemId, ProductIdentity productId, decimal unitPrice, int quantity)
        {
            var orderItem = _orderItems.FirstOrDefault(e => e.Id == orderItemId);

            if (orderItem == null)
            {
                throw new ArgumentException($"Order detail {orderItemId} does not exist in the order");
            }

            orderItem.ProductId = productId;
            orderItem.UnitPrice = unitPrice;
            orderItem.Quantity = quantity;
        }

        public void Archive()
        {
            Status = OrderStatus.Archived;
        }

        public void Submit()
        {
            Status = OrderStatus.Submitted;
        }

        public void Cancel()
        {
            Status = OrderStatus.Cancelled;
        }
    }
}