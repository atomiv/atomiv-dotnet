using FluentAssertions;
using Moq;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Handlers.Orders;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Core.Application.UnitTest.Orders.Commands
{
    public class UpdateOrderCommandTest
    {
        private readonly Mock<IOrderFactory> _orderFactoryMock;
        private readonly Mock<IProductReadonlyRepository> _productReadonlyRepositoryMock;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public UpdateOrderCommandTest()
        {
            _orderFactoryMock = new Mock<IOrderFactory>(MockBehavior.Strict);
            _productReadonlyRepositoryMock = new Mock<IProductReadonlyRepository>(MockBehavior.Strict);
            _orderRepositoryMock = new Mock<IOrderRepository>(MockBehavior.Strict);
            _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
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

            var products = new List<Product>
            {
                new Product(new ProductIdentity(productId2), "code", "name", productId2Price, true),
                new Product(new ProductIdentity(productId3), "code", "name", productId3Price, true),
            };

            var order = new Order(new OrderIdentity(id),
                new CustomerIdentity(customerId),
                new DateTime(2019, 12, 15),
                OrderStatus.Draft,
                new List<OrderItem>
                {
                    new OrderItem(new OrderItemIdentity(orderItemId1), new ProductIdentity(productId1), productId1Price, 50, OrderItemStatus.Allocated),
                    new OrderItem(new OrderItemIdentity(orderItemId2), new ProductIdentity(productId2), productId2Price, 60, OrderItemStatus.Unavailable),
                });

            var command = new EditOrderCommand
            {
                Id = id,
                OrderItems = new List<EditOrderItemCommand>
                {
                    new EditOrderItemCommand
                    {
                        Id = orderItemId1,
                        ProductId = productId2,
                        Quantity = 72,
                    },

                    new EditOrderItemCommand
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
                OrderStatus.Draft,
                new List<OrderItem>
                {
                    new OrderItem(new OrderItemIdentity(orderItemId1), new ProductIdentity(productId2), productId2Price, 72, OrderItemStatus.Allocated),
                    new OrderItem(new OrderItemIdentity(orderItemId3), new ProductIdentity(productId3), productId3Price, 84, OrderItemStatus.Allocated),
                });

            var expectedResponse = new EditOrderCommandResponse
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

            var productIds = new List<ProductIdentity>
            {
                new ProductIdentity(productId2),
                new ProductIdentity(productId3),
            };

            _orderRepositoryMock
                .Setup(e => e.FindAsync(new OrderIdentity(id)))
                .ReturnsAsync(order);

            _productReadonlyRepositoryMock
                .Setup(e => e.FindReadonlyAsync(productIds))
                .ReturnsAsync(products);

            _orderFactoryMock
                .Setup(e => e.CreateOrderItem(new ProductIdentity(productId3), productId3Price, 84))
                .Returns(new OrderItem(new OrderItemIdentity(orderItemId3), new ProductIdentity(productId3), productId3Price, 60, OrderItemStatus.Allocated));

            _orderRepositoryMock
                .Setup(e => e.UpdateAsync(expectedUpdatedOrder))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock
                .Setup(e => e.CommitAsync())
                .Returns(Task.CompletedTask);

            _mapperMock
                .Setup(e => e.Map<Order, EditOrderCommandResponse>(expectedUpdatedOrder))
                .Returns(expectedResponse);


            // Act

            var handler = new EditOrderCommandHandler(_orderFactoryMock.Object,
                _productReadonlyRepositoryMock.Object,
                _orderRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapperMock.Object);

            // Assert

            var response = await handler.HandleAsync(command);

            _orderRepositoryMock.Verify(e => e.FindAsync(new OrderIdentity(id)), Times.Once());
            _productReadonlyRepositoryMock.Verify(e => e.FindReadonlyAsync(productIds), Times.Once());
            _orderFactoryMock.Verify(e => e.CreateOrderItem(new ProductIdentity(productId3), productId3Price, 84), Times.Once());
            _orderRepositoryMock.Verify(e => e.UpdateAsync(expectedUpdatedOrder), Times.Once());
            _mapperMock.Verify(e => e.Map<Order, EditOrderCommandResponse>(expectedUpdatedOrder), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
