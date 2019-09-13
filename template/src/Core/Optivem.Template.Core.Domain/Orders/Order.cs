using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System.Collections.ObjectModel;

namespace Optivem.Template.Core.Domain.Orders
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