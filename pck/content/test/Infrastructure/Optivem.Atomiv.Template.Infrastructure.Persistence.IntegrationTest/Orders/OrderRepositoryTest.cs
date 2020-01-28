using Optivem.Atomiv.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.IntegrationTest.Orders
{
    public class OrderRepositoryTest : BaseTest
    {
        public OrderRepositoryTest(Fixture fixture) : base(fixture)
        {
        }

        public async Task CanUpdateExistingOrder()
        {
            // Arrange

            var customers = await CreateSomeCustomersAsync();
            var products = await CreateSomeProductsAsync();

            var orders = await CreateSomeOrdersAsync(customers, products);

            var customer = customers[2];

            var product1 = products[1];
            var product2 = products[2];
            var product3 = products[3];

            var orderItem1 = _orderFactory.CreateNewOrderItem(product1.Id, 22.56m, 40);
            var orderItem2 = _orderFactory.CreateNewOrderItem(product2.Id, 34.46m, 50);
            var orderItem3 = _orderFactory.CreateNewOrderItem(product3.Id, 48.24m, 60);

            var orderItems = new List<OrderItem>
            {
                orderItem1,
                orderItem2,
                orderItem3,
            };

            var order = _orderFactory.CreateNewOrder(customer.Id, orderItems);


            // TODO: VC: Continue
            // order.UpdateOrderItem(orderItem1);


            /*

            var createOrderResponse = createOrderResponses[1].Data;
            var id = createOrderResponse.Id;

            var orderCustomerId = createOrderResponse.CustomerId;
            var orderStatus = createOrderResponse.Status;

            var updateRequest = new UpdateOrderCommand
            {
                Id = id,
                OrderItems = new List<UpdateOrderItemCommand>
                {
                    new UpdateOrderItemCommand
                    {
                        Id = createOrderResponse.OrderItems[0].Id,
                        ProductId = productId_1,
                        Quantity = 72,
                    },

                    new UpdateOrderItemCommand
                    {
                        Id = null,
                        ProductId = productId_2,
                        Quantity = 84,
                    }
                },
            };

            // Act

            var updateHttpResponse = await Fixture.Api.Orders.UpdateOrderAsync(updateRequest);
            */
        }



        /*
         * 
         * 




            // Assert

            updateHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updateResponse = updateHttpResponse.Data;

            updateResponse.Id.Should().Be(updateRequest.Id);
            updateResponse.CustomerId.Should().Be(orderCustomerId);
            updateResponse.Status.Should().Be(orderStatus);

            updateResponse.OrderItems.Should().NotBeNull();
            updateResponse.OrderItems.Count.Should().Be(updateRequest.OrderItems.Count);

            for (int i = 0; i < updateRequest.OrderItems.Count; i++)
            {
                var updateRequestOrderDetail = updateRequest.OrderItems[i];
                var updateResponseOrderDetail = updateResponse.OrderItems[i];

                if (updateRequestOrderDetail.Id != null)
                {
                    updateResponseOrderDetail.Id.Should().Be(updateRequestOrderDetail.Id.Value);
                }
                else
                {
                    updateResponseOrderDetail.Id.Should().NotBeEmpty();
                }

                updateResponseOrderDetail.ProductId.Should().Be(updateRequestOrderDetail.ProductId);
                updateResponseOrderDetail.Quantity.Should().Be(updateRequestOrderDetail.Quantity);
                updateResponseOrderDetail.Status.Should().Be(OrderItemStatus.Allocated);
            }

            var findRequest = new FindOrderQuery { Id = updateResponse.Id };

            var findHttpResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(updateResponse);
         * 
         * 
         */
    }
}
