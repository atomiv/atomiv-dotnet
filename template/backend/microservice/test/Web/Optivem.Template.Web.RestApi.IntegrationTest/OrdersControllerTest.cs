using Optivem.Framework.Test.Xunit;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Infrastructure.Persistence.Records;
using Optivem.Template.Web.RestApi.IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Web.RestApi.IntegrationTest
{
    public class OrdersControllerTest : Test
    {
        private readonly List<CustomerRecord> _customerRecords;
        private readonly List<ProductRecord> _productRecords;
        private readonly List<OrderRecord> _orderRecords;

        public OrdersControllerTest(Fixture fixture) : base(fixture)
        {
        }





        [Fact(Skip = "In progress")]
        public async Task UpdateOrder_ValidRequest_ReturnsResponse()
        {
            var product1Record = _productRecords[2];
            var product2Record = _productRecords[3];

            var orderRecord = _orderRecords[1];

            var orderStatusId = orderRecord.OrderStatusId;

            var updateRequest = new UpdateOrderCommand
            {
                Id = orderRecord.Id,
                OrderItems = new List<UpdateOrderItemCommand>
                {
                    new UpdateOrderItemCommand
                    {
                        Id = orderRecord.OrderItems.ElementAt(0).Id,
                        ProductId = product1Record.Id,
                        Quantity = 72,
                    },

                    new UpdateOrderItemCommand
                    {
                        Id = null,
                        ProductId = product2Record.Id,
                        Quantity = 84,
                    }
                },
            };

            var updateApiResponse = await Fixture.Api.Orders.UpdateOrderAsync(updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateApiResponse.StatusCode);

            var updateResponse = updateApiResponse.Data;

            Assert.Equal(updateRequest.Id, updateResponse.Id);
            Assert.Equal(orderRecord.CustomerId, updateResponse.CustomerId);
            Assert.Equal((OrderStatus)orderStatusId, updateResponse.Status);

            Assert.NotNull(updateResponse.OrderItems);

            Assert.Equal(updateRequest.OrderItems.Count, updateResponse.OrderItems.Count);

            for (int i = 0; i < updateRequest.OrderItems.Count; i++)
            {
                var updateRequestOrderDetail = updateRequest.OrderItems[i];
                var updateResponseOrderDetail = updateResponse.OrderItems[i];

                if (updateRequestOrderDetail.Id != null)
                {
                    Assert.Equal(updateRequestOrderDetail.Id, updateResponseOrderDetail.Id);
                }
                else
                {
                    AssertUtilities.NotEmpty(updateResponseOrderDetail.Id);
                }

                Assert.Equal(updateRequestOrderDetail.ProductId, updateResponseOrderDetail.ProductId);
                Assert.Equal(updateRequestOrderDetail.Quantity, updateResponseOrderDetail.Quantity);
                Assert.Equal(OrderItemStatus.Allocated, updateResponseOrderDetail.Status);
            }

            var findRequest = new FindOrderQuery { Id = updateResponse.Id };

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findApiResponse.StatusCode);

            var findResponse = findApiResponse.Data;

            Assert.Equal(updateResponse.Id, findResponse.Id);
            Assert.Equal(updateResponse.CustomerId, updateResponse.CustomerId);
            Assert.Equal(updateResponse.Status, updateResponse.Status);

            Assert.NotNull(findResponse.OrderItems);

            Assert.Equal(updateResponse.OrderItems.Count, findResponse.OrderItems.Count);

            for (int i = 0; i < updateResponse.OrderItems.Count; i++)
            {
                var updateResponseOrderDetail = updateResponse.OrderItems[i];
                var findResponseOrderDetail = findResponse.OrderItems[i];

                Assert.Equal(updateResponseOrderDetail.Id, findResponseOrderDetail.Id);
                Assert.Equal(updateResponseOrderDetail.ProductId, findResponseOrderDetail.ProductId);
                Assert.Equal(updateResponseOrderDetail.Quantity, findResponseOrderDetail.Quantity);
                Assert.Equal(updateResponseOrderDetail.Status, findResponseOrderDetail.Status);
            }
        }

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
    }
}
