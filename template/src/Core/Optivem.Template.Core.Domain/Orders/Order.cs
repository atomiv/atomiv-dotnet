using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Template.Core.Domain.Orders
{
    public class Order : AggregateRoot<OrderIdentity>
    {
        public Order(OrderIdentity id, CustomerIdentity customerId, OrderStatus status, IEnumerable<OrderDetail> orderDetails) 
            : base(id)
        {
            CustomerId = customerId;
            Status = status;
            OrderDetails = orderDetails.ToList().AsReadOnly();
        }

        public CustomerIdentity CustomerId { get; }

        public OrderStatus Status { get; private set; }

        public ReadOnlyCollection<OrderDetail> OrderDetails { get; }

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