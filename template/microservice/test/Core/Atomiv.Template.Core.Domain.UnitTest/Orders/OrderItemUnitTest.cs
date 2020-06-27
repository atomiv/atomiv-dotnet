using Atomiv.Infrastructure.System;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using FluentAssertions;
using System;
using Xunit;

namespace Atomiv.Template.Core.Domain.UnitTest.Orders
{
    public class OrderItemUnitTest
    {
        [Fact]
        public void CanConstructValidOrderItem()
        {
            // Arrange

            var id = new OrderItemIdentity(StringGenerator.NewString());
            var productId = new ProductIdentity(StringGenerator.NewString());
            var unitPrice = 20.56m;
            var quantity = 4;
            var status = OrderItemStatus.Allocated;

            // Act

            var orderItem = new OrderItem(id, productId, unitPrice, quantity, status);

            // Assert

            orderItem.Id.Should().Be(id);
            orderItem.ProductId.Should().Be(productId);
            orderItem.UnitPrice.Should().Be(unitPrice);
            orderItem.Quantity.Should().Be(quantity);
            orderItem.Status.Should().Be(status);
        }

        [Fact]
        public void CanCopyConstructValidOrderItem()
        {
            // Arrange

            var id = new OrderItemIdentity(StringGenerator.NewString());
            var productId = new ProductIdentity(StringGenerator.NewString());
            var unitPrice = 20.56m;
            var quantity = 4;
            var status = OrderItemStatus.Allocated;

            var originalOrderItem = new OrderItem(id, productId, unitPrice, quantity, status);

            // Act

            var clonedOrderItem = new OrderItem(originalOrderItem);

            // Assert

            clonedOrderItem.Id.Should().Be(id);
            clonedOrderItem.ProductId.Should().Be(productId);
            clonedOrderItem.UnitPrice.Should().Be(unitPrice);
            clonedOrderItem.Quantity.Should().Be(quantity);
            clonedOrderItem.Status.Should().Be(status);
        }
    }
}
