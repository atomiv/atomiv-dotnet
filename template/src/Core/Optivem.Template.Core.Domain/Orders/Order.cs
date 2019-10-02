using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Template.Core.Domain.Orders
{
    public class Order : AggregateRoot<OrderIdentity>
    {
        private CustomerIdentity _customerId;
        private List<OrderDetail> _orderDetails;

        public Order(OrderIdentity id, CustomerIdentity customerId, OrderStatus status, IEnumerable<OrderDetail> orderDetails) 
            : base(id)
        {
            CustomerId = customerId;
            Status = status;
            OrderDetails = orderDetails.ToList().AsReadOnly();
        }

        public CustomerIdentity CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value ?? throw new ArgumentNullException();
            }
        }

        public OrderStatus Status { get; private set; }

        public ReadOnlyCollection<OrderDetail> OrderDetails
        {
            get { return _orderDetails.AsReadOnly(); }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }

                if(!value.Any())
                {
                    throw new ArgumentException("There are no order items");
                }

                _orderDetails = value.ToList();
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if(orderDetail == null)
            {
                throw new ArgumentNullException();
            }

            // TODO: VC: Checking if id exists

            _orderDetails.Add(orderDetail);
        }

        public void RemoveOrderDetail(OrderDetailIdentity orderDetailId)
        {
            var orderDetail = _orderDetails.FirstOrDefault(e => e.Id == orderDetailId);

            if(orderDetail == null)
            {
                throw new ArgumentException($"Order detail {orderDetailId} does not exist in the order");
            }

            _orderDetails.Remove(orderDetail);
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