using Atomiv.Infrastructure.System;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Atomiv.Template.Core.Domain.UnitTest.Orders
{
    public class OrderUnitTest
    {
        [Fact]
        public void CanConstructValidOrder()
        {
            // Arrange

            var id = new OrderIdentity(StringGenerator.NewString());
            var customerId = new CustomerIdentity(StringGenerator.NewString());
            var orderDate = new DateTime(2020, 4, 3);
            var status = OrderStatus.Draft;
            var orderItems = new List<IReadonlyOrderItem>
            {
                new OrderItem(new OrderItemIdentity(StringGenerator.NewString()), 
                    new ProductIdentity(StringGenerator.NewString()), 40.56m, 20, OrderItemStatus.Pending),

                new OrderItem(new OrderItemIdentity(StringGenerator.NewString()),
                    new ProductIdentity(StringGenerator.NewString()), 57.12m, 30, OrderItemStatus.Allocated),
            };

            // Act

            var order = new Order(id, customerId, orderDate, status, orderItems);

            // Assert

            order.Id.Should().Be(id);
            order.CustomerId.Should().Be(customerId);
            order.OrderDate.Should().Be(orderDate);
            order.Status.Should().Be(status);
            order.OrderItems.Should().BeEquivalentTo(orderItems);
        }

        [Fact]
        public void CanCancelDraftOrder()
        {
            // Arrange

            var order = CreateDraftOrder();

            // Act

            order.Cancel();

            // Assert

            order.Status.Should().Be(OrderStatus.Cancelled);
        }



        private Order CreateDraftOrder()
        {
            var id = new OrderIdentity(StringGenerator.NewString());
            var customerId = new CustomerIdentity(StringGenerator.NewString());
            var orderDate = new DateTime(2020, 4, 3);
            var status = OrderStatus.Draft;
            var orderItems = new List<IReadonlyOrderItem>
            {
                new OrderItem(new OrderItemIdentity(StringGenerator.NewString()),
                    new ProductIdentity(StringGenerator.NewString()), 40.56m, 20, OrderItemStatus.Pending),

                new OrderItem(new OrderItemIdentity(StringGenerator.NewString()),
                    new ProductIdentity(StringGenerator.NewString()), 57.12m, 30, OrderItemStatus.Allocated),
            };

            return new Order(id, customerId, orderDate, status, orderItems);
        }

    }
}
