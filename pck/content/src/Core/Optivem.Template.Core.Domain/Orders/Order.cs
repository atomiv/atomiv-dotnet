using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Template.Core.Domain.Orders
{
    public class Order : AggregateRoot<OrderIdentity, int>
    {
        private CustomerIdentity _customerId;
        private List<OrderItem> _orderItems;

        public Order(OrderIdentity id, CustomerIdentity customerId, DateTime orderDate, OrderStatus status, IEnumerable<OrderItem> orderDetails)
            : base(id)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            Status = status;
            OrderItems = orderDetails.ToList().AsReadOnly();
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

        public ReadOnlyCollection<OrderItem> OrderItems
        {
            get { return _orderItems.AsReadOnly(); }
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

                _orderItems = value.ToList();
            }
        }

        public void AddOrderDetail(OrderItem orderDetail)
        {
            if (orderDetail == null)
            {
                throw new ArgumentNullException();
            }

            // TODO: VC: Checking if id exists

            _orderItems.Add(orderDetail);
        }

        public void RemoveOrderDetail(OrderItemIdentity orderDetailId)
        {
            var orderDetail = _orderItems.FirstOrDefault(e => e.Id == orderDetailId);

            if (orderDetail == null)
            {
                throw new ArgumentException($"Order detail {orderDetailId} does not exist in the order");
            }

            _orderItems.Remove(orderDetail);
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