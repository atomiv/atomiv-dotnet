using Optivem.Atomiv.Core.Domain;
using Optivem.Generator.Core.Domain.Customers;
using System;
using System.Collections.ObjectModel;

namespace Optivem.Generator.Core.Domain.Orders
{
    public class Order : AggregateRoot<OrderIdentity>
    {
        public Order(OrderIdentity id, CustomerIdentity customerId, OrderStatus status, ReadOnlyCollection<OrderDetail> orderDetails) 
            : base(id)
        {
            CustomerId = customerId;
            Status = status;
            OrderDetails = orderDetails;
        }

        public CustomerIdentity CustomerId { get; }

        public OrderStatus Status { get; }

        public ReadOnlyCollection<OrderDetail> OrderDetails { get; }

        public void Archive()
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}