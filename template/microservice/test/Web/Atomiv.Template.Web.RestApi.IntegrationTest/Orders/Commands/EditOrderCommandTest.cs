using FluentAssertions;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Common.Orders;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Orders.Commands
{
    public class EditOrderCommandTest : BaseTest
    {
        public EditOrderCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task UpdateOrder_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createCustomerResponses = await CreateSampleCustomersAsync();
            var createProductResponses = await CreateSampleProductsAsync();
            var createOrderResponses = await CreateSampleOrdersAsync(createCustomerResponses, createProductResponses);

            var productId_1 = createProductResponses[2].Data.Id;
            var productId_2 = createProductResponses[3].Data.Id;

            var createOrderResponse = createOrderResponses[1].Data;
            var id = createOrderResponse.Id;

            var orderCustomerId = createOrderResponse.CustomerId;
            var orderStatus = createOrderResponse.Status;

            var updateRequest = new EditOrderCommand
            {
                Id = id,
                OrderItems = new List<EditOrderItemCommand>
                {
                    new EditOrderItemCommand
                    {
                        Id = createOrderResponse.OrderItems[0].Id,
                        ProductId = productId_1,
                        Quantity = 72,
                    },

                    new EditOrderItemCommand
                    {
                        Id = null,
                        ProductId = productId_2,
                        Quantity = 84,
                    }
                },
            };

            // Act

            var updateHttpResponse = await Fixture.Api.Orders.EditOrderAsync(updateRequest, header);

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
                    updateResponseOrderDetail.Id.Should().Be(updateRequestOrderDetail.Id);
                }
                else
                {
                    updateResponseOrderDetail.Id.Should().NotBeEmpty();
                }

                updateResponseOrderDetail.ProductId.Should().Be(updateRequestOrderDetail.ProductId);
                updateResponseOrderDetail.Quantity.Should().Be(updateRequestOrderDetail.Quantity);
                updateResponseOrderDetail.Status.Should().Be(OrderItemStatus.Pending);
            }

            // TODO: VC: Fix test

            /*
            var findRequest = new FindOrderQuery { Id = updateResponse.Id };

            var findHttpResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(updateResponse);
            */
        }



        /*
         * 



        [Fact]
        public async Task UpdateOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = Guid.NewGuid();
            var orderItemId = Guid.NewGuid();

            var updateRequest = new UpdateOrderCommand
            {
                Id = id,
                OrderItems = new List<UpdateOrderItemCommand>
                {
                    new UpdateOrderItemCommand
                    {
                        Id = orderItemId,
                        ProductId = _productRecords[0].Id,
                        Quantity = 40,
                    },
                },
            };

            var updateApiResponse = await Fixture.Api.Orders.UpdateOrderAsync(updateRequest);

            Assert.Equal(HttpStatusCode.NotFound, updateApiResponse.StatusCode);
        }

        [Fact(Skip = "In progress")]
        public async Task UpdateOrder_InvalidRequest_ThrowsInvalidRequestException()
        {
            var orderRecord = _orderRecords[0];

            var updateRequest = new UpdateOrderCommand
            {
                Id = orderRecord.Id,
                OrderItems = null,
            };

            var updateApiResponse = await Fixture.Api.Orders.UpdateOrderAsync(updateRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, updateApiResponse.StatusCode);
        }
         * 
         * 
         */

    }
}
