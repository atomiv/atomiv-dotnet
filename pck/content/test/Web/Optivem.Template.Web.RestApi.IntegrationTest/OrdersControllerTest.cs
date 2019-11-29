using Optivem.Framework.Test.Xunit;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Records;
using Optivem.Template.Web.RestApi.IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Web.RestApi.IntegrationTest
{
    public class OrdersControllerTest : ControllerTest
    {
        private readonly List<CustomerRecord> _customerRecords;
        private readonly List<ProductRecord> _productRecords;
        private readonly List<OrderRecord> _orderRecords;

        public OrdersControllerTest(ControllerFixture fixture) : base(fixture)
        {
            _customerRecords = new List<CustomerRecord>
            {
                new CustomerRecord
                {
                    FirstName = "Mary2",
                    LastName = "Smith2",
                },

                new CustomerRecord
                {
                    FirstName = "John2",
                    LastName = "McDonald2",
                },

                new CustomerRecord
                {
                    FirstName = "Jake2",
                    LastName = "McDonald2",
                }
            };

            Fixture.Db.AddRange(_customerRecords);

            _productRecords = new List<ProductRecord>
            {
                new ProductRecord
                {
                    ProductCode = "APP2",
                    ProductName = "Apple2",
                    ListPrice = 102.50m,
                },

                new ProductRecord
                {
                    ProductCode = "BAN2",
                    ProductName = "Banana2",
                    ListPrice = 302.99m,
                },

                new ProductRecord
                {
                    ProductCode = "ORG2",
                    ProductName = "Orange2",
                    ListPrice = 102.50m,
                },

                new ProductRecord
                {
                    ProductCode = "MAN2",
                    ProductName = "Mango2",
                    ListPrice = 500.99m,
                },
            };

            Fixture.Db.AddRange(_productRecords);

            _orderRecords = new List<OrderRecord>
            {
                new OrderRecord
                {
                    CustomerId = _customerRecords[0].Id,
                    OrderStatusId = OrderStatus.Invoiced,

                    OrderItems = new List<OrderItemRecord>
                    {
                        new OrderItemRecord
                        {
                            ProductId = _productRecords[0].Id,
                            UnitPrice = _productRecords[0].ListPrice,
                            Quantity = 30,
                            StatusId = OrderItemStatus.NoStock,
                        },

                        new OrderItemRecord
                        {
                            ProductId = _productRecords[1].Id,
                            UnitPrice = _productRecords[1].ListPrice,
                            Quantity = 60,
                            StatusId = OrderItemStatus.OnOrder,
                        },
                    },
                },

                new OrderRecord
                {
                    CustomerId = _customerRecords[1].Id,
                    OrderStatusId = OrderStatus.Shipped,

                    OrderItems = new List<OrderItemRecord>
                    {
                        new OrderItemRecord
                        {
                            ProductId = _productRecords[1].Id,
                            UnitPrice = _productRecords[1].ListPrice,
                            Quantity = 40,
                            StatusId = OrderItemStatus.Allocated,
                        },

                        new OrderItemRecord
                        {
                            ProductId = _productRecords[2].Id,
                            UnitPrice = _productRecords[2].ListPrice,
                            Quantity = 50,
                            StatusId = OrderItemStatus.Invoiced,
                        },
                    },
                },
            };

            Fixture.Db.AddRange(_orderRecords);
        }

        [Fact(Skip = "In progress")]
        public async Task CreateOrder_ValidRequest_ReturnsResponse()
        {
            var customerRecord = _customerRecords[0];

            var product1Record = _productRecords[0];
            var product2Record = _productRecords[1];

            var createRequest = new CreateOrderRequest
            {
                CustomerId = customerRecord.Id,
                OrderItems = new List<CreateOrderItemRequest>
                {
                    new CreateOrderItemRequest
                    {
                        ProductId = product1Record.Id,
                        Quantity = 10,
                    },

                    new CreateOrderItemRequest
                    {
                        ProductId = product2Record.Id,
                        Quantity = 20,
                    }
                },
            };

            var createApiResponse = await Fixture.Api.Orders.CreateOrderAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createApiResponse.StatusCode);

            var createResponse = createApiResponse.Data;

            AssertUtilities.NotEmpty(createResponse.Id);
            Assert.Equal(createRequest.CustomerId, createResponse.CustomerId);
            Assert.Equal(OrderStatus.New, createResponse.Status);

            Assert.NotNull(createResponse.OrderItems);

            Assert.Equal(createRequest.OrderItems.Count, createResponse.OrderItems.Count);

            for (int i = 0; i < createRequest.OrderItems.Count; i++)
            {
                var createRequestOrderDetail = createRequest.OrderItems[i];
                var createResponseOrderDetail = createResponse.OrderItems[i];

                AssertUtilities.NotEmpty(createResponseOrderDetail.Id);
                Assert.Equal(createRequestOrderDetail.ProductId, createResponseOrderDetail.ProductId);
                Assert.Equal(createRequestOrderDetail.Quantity, createResponseOrderDetail.Quantity);
                Assert.Equal(OrderItemStatus.Allocated, createResponseOrderDetail.Status);
            }

            var findRequest = new FindOrderRequest { Id = createResponse.Id };

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);
            var findResponse = findApiResponse.Data;

            Assert.Equal(createResponse.Id, findResponse.Id);
            Assert.Equal(createResponse.CustomerId, createResponse.CustomerId);
            Assert.Equal(createResponse.Status, createResponse.Status);

            Assert.NotNull(findResponse.OrderItems);

            Assert.Equal(createResponse.OrderItems.Count, findResponse.OrderItems.Count);

            for (int i = 0; i < createResponse.OrderItems.Count; i++)
            {
                var createResponseOrderDetail = createResponse.OrderItems[i];
                var findResponseOrderDetail = findResponse.OrderItems[i];

                Assert.Equal(createResponseOrderDetail.Id, findResponseOrderDetail.Id);
                Assert.Equal(createResponseOrderDetail.ProductId, findResponseOrderDetail.ProductId);
                Assert.Equal(createResponseOrderDetail.Quantity, findResponseOrderDetail.Quantity);
                Assert.Equal(createResponseOrderDetail.Status, findResponseOrderDetail.Status);
            }
        }

        [Fact(Skip = "In progress")]
        public async Task CreateOrder_InvalidRequest_ThrowsInvalidRequestException()
        {
            var customerId = Guid.NewGuid();

            var createRequest = new CreateOrderRequest
            {
                CustomerId = customerId,
                OrderItems = null,
            };

            var createApiResponse = await Fixture.Api.Orders.CreateOrderAsync(createRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, createApiResponse.StatusCode);
        }

        [Fact]
        public async Task FindOrder_ValidRequest_ReturnsOrder()
        {
            var orderRecord = _orderRecords[0];
            var id = orderRecord.Id;

            var findRequest = new FindOrderRequest { Id = id };

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findApiResponse.StatusCode);

            var findResponse = findApiResponse.Data;

            Assert.Equal(orderRecord.Id, findResponse.Id);
            Assert.Equal(orderRecord.CustomerId, findResponse.CustomerId);
            Assert.Equal((OrderStatus)orderRecord.OrderStatusId, findResponse.Status);

            Assert.NotNull(findResponse.OrderItems);

            Assert.Equal(orderRecord.OrderItems.Count, findResponse.OrderItems.Count);

            for (int i = 0; i < orderRecord.OrderItems.Count; i++)
            {
                var orderDetailRecord = orderRecord.OrderItems.ToList()[i];
                var findResponseDetail = findResponse.OrderItems[i];

                Assert.Equal(orderDetailRecord.Id, findResponseDetail.Id);
                Assert.Equal(orderDetailRecord.ProductId, findResponseDetail.ProductId);
                Assert.Equal(orderDetailRecord.Quantity, findResponseDetail.Quantity);
                Assert.Equal(orderDetailRecord.StatusId, findResponseDetail.Status);
            }
        }

        [Fact]
        public async Task FindOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = Guid.NewGuid();

            var findRequest = new FindOrderRequest { Id = id };

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            Assert.Equal(HttpStatusCode.NotFound, findApiResponse.StatusCode);
        }

        [Fact(Skip = "In progress")]
        public async Task UpdateOrder_ValidRequest_ReturnsResponse()
        {
            var product1Record = _productRecords[2];
            var product2Record = _productRecords[3];

            var orderRecord = _orderRecords[1];

            var orderStatusId = orderRecord.OrderStatusId;

            var updateRequest = new UpdateOrderRequest
            {
                Id = orderRecord.Id,
                OrderItems = new List<UpdateOrderItemRequest>
                {
                    new UpdateOrderItemRequest
                    {
                        Id = orderRecord.OrderItems.ElementAt(0).Id,
                        ProductId = product1Record.Id,
                        Quantity = 72,
                    },

                    new UpdateOrderItemRequest
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

            var findRequest = new FindOrderRequest { Id = updateResponse.Id };

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

            var updateRequest = new UpdateOrderRequest
            {
                Id = id,
                OrderItems = new List<UpdateOrderItemRequest>
                {
                    new UpdateOrderItemRequest
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

            var updateRequest = new UpdateOrderRequest
            {
                Id = orderRecord.Id,
                OrderItems = null,
            };

            var updateApiResponse = await Fixture.Api.Orders.UpdateOrderAsync(updateRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, updateApiResponse.StatusCode);
        }
    }
}
