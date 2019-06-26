using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers.ValueObjects;
using Optivem.Template.Core.Domain.Orders.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Optivem.Template.Core.Domain.Orders.Entities
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
