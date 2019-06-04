using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Domain.Identities;
using Optivem.NorthwindLite.Core.Domain.ValueObjects;
using System.Collections.ObjectModel;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class Order : AggregateRoot<OrderIdentity>
    {
        // TODO: VC: Accept order details as IEnumerable

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
    }
}