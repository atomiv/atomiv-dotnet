using FluentAssertions;
using Moq;
using Optivem.Atomiv.Core.Application.Mapping;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;
using Optivem.Atomiv.Template.Core.Common.Orders;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using Optivem.Atomiv.Template.Core.Domain.Orders;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Core.Application.UnitTest.Orders.Commands
{
    public class UpdateOrderCommandTest
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IProductReadRepository> _productReadRepositoryMock;
        private readonly Mock<IOrderFactory> _orderFactoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public UpdateOrderCommandTest()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>(MockBehavior.Strict);
            _productReadRepositoryMock = new Mock<IProductReadRepository>(MockBehavior.Strict);
            _orderFactoryMock = new Mock<IOrderFactory>(MockBehavior.Strict);
            _mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        }

        [Fact]
        public async Task HandleAsync_Valid()
        {
            // Arrange

            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");
            var customerId = Guid.Parse("711d5de4-628a-4acd-98c4-8ce099b149bc");
            var orderItemId1 = Guid.Parse("c58b1858-2d67-4aee-9bfd-df1f9ac37227");
            var orderItemId2 = Guid.Parse("f7319c98-a3e0-42be-9e4f-dcc1e3e1dea1");
            var orderItemId3 = Guid.Parse("4455370b-0351-4cd8-a191-3c28841ff6be");

            var productId1 = Guid.Parse("4e12839c-b431-4a4d-a7e0-80949d478945");
            var productId2 = Guid.Parse("a9fbe198-edcd-4b27-9a0d-38420df95b02");
            var productId3 = Guid.Parse("cbb3650a-3c47-4608-ae88-20ef603d9d25");

            var productId1Price = 20.46m;
            var productId2Price = 25.68m;
            var productId3Price = 34.96m;

            var order = new Order(new OrderIdentity(id),
                new CustomerIdentity(customerId),
                new DateTime(2019, 12, 15),
                OrderStatus.New,
                new List<OrderItem>
                {
                    new OrderItem(new OrderItemIdentity(orderItemId1), new ProductIdentity(productId1), productId1Price, 50, OrderItemStatus.Allocated),
                    new OrderItem(new OrderItemIdentity(orderItemId2), new ProductIdentity(productId2), productId2Price, 60, OrderItemStatus.OnOrder),
                });

            var command = new UpdateOrderCommand
            {
                Id = id,
                OrderItems = new List<UpdateOrderItemCommand>
                {
                    new UpdateOrderItemCommand
                    {
                        Id = orderItemId1,
                        ProductId = productId2,
                        Quantity = 72,
                    },

                    new UpdateOrderItemCommand
                    {
                        Id = null,
                        ProductId = productId3,
                        Quantity = 84,
                    }
                },
            };

            var expectedUpdatedOrder = new Order(new OrderIdentity(id),
                new CustomerIdentity(customerId),
                new DateTime(2019, 12, 15),
                OrderStatus.New,
                new List<OrderItem>
                {
                    new OrderItem(new OrderItemIdentity(orderItemId1), new ProductIdentity(productId2), productId2Price, 72, OrderItemStatus.Allocated),
                    new OrderItem(new OrderItemIdentity(orderItemId3), new ProductIdentity(productId3), productId3Price, 84, OrderItemStatus.Allocated),
                });

            var expectedResponse = new UpdateOrderCommandResponse
            {
                Id = id,
                CustomerId = customerId,
                Status = order.Status,
                OrderItems = new List<UpdateOrderItemCommandResponse>
                {
                    new UpdateOrderItemCommandResponse
                    {
                        Id = orderItemId1,
                        ProductId = productId2,
                        Quantity = 72,
                    },

                    new UpdateOrderItemCommandResponse
                    {
                        Id = orderItemId3,
                        ProductId = productId3,
                        Quantity = 84,
                    },
                },
            };

            _orderRepositoryMock
                .Setup(e => e.FindAsync(new OrderIdentity(id)))
                .ReturnsAsync(order);

            _productReadRepositoryMock
                .Setup(e => e.GetPriceAsync(productId2))
                .ReturnsAsync(productId2Price);

            _productReadRepositoryMock
                .Setup(e => e.GetPriceAsync(productId3))
                .ReturnsAsync(productId3Price);

            _orderFactoryMock
                .Setup(e => e.CreateNewOrderItem(new ProductIdentity(productId3), productId3Price, 84))
                .Returns(new OrderItem(new OrderItemIdentity(orderItemId3), new ProductIdentity(productId3), productId3Price, 60, OrderItemStatus.Allocated));

            _orderRepositoryMock
                .Setup(e => e.UpdateAsync(expectedUpdatedOrder))
                .Returns(Task.CompletedTask);

            _mapperMock
                .Setup(e => e.Map<Order, UpdateOrderCommandResponse>(expectedUpdatedOrder))
                .Returns(expectedResponse);


            // Act

            var handler = new UpdateOrderCommandHandler(_orderRepositoryMock.Object,
                _productReadRepositoryMock.Object,
                _orderFactoryMock.Object,
                _mapperMock.Object);

            // Assert

            var response = await handler.HandleAsync(command);

            _orderRepositoryMock.Verify(e => e.FindAsync(new OrderIdentity(id)), Times.Once());
            _productReadRepositoryMock.Verify(e => e.GetPriceAsync(productId2), Times.Once());
            _productReadRepositoryMock.Verify(e => e.GetPriceAsync(productId3), Times.Once());
            _orderFactoryMock.Verify(e => e.CreateNewOrderItem(new ProductIdentity(productId3), productId3Price, 84), Times.Once());
            _orderRepositoryMock.Verify(e => e.UpdateAsync(expectedUpdatedOrder), Times.Once());
            _mapperMock.Verify(e => e.Map<Order, UpdateOrderCommandResponse>(expectedUpdatedOrder), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
