using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
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
                    CustomerRecordId = _customerRecords[0].Id,
                    OrderStatusRecordId = (int)OrderStatus.Invoiced,

                    OrderDetailRecords = new List<OrderDetailRecord>
                    {
                        new OrderDetailRecord
                        {
                            ProductRecordId = _productRecords[0].Id,
                            UnitPrice = _productRecords[0].ListPrice,
                            Quantity = 30,
                            OrderDetailStatusRecordId = (int)OrderItemStatus.NoStock,
                        },

                        new OrderDetailRecord
                        {
                            ProductRecordId = _productRecords[1].Id,
                            UnitPrice = _productRecords[1].ListPrice,
                            Quantity = 60,
                            OrderDetailStatusRecordId = (int)OrderItemStatus.OnOrder,
                        },
                    },
                },

                new OrderRecord
                {
                    CustomerRecordId = _customerRecords[1].Id,
                    OrderStatusRecordId = (int)OrderStatus.Shipped,

                    OrderDetailRecords = new List<OrderDetailRecord>
                    {
                        new OrderDetailRecord
                        {
                            ProductRecordId = _productRecords[1].Id,
                            UnitPrice = _productRecords[1].ListPrice,
                            Quantity = 40,
                            OrderDetailStatusRecordId = (int)OrderItemStatus.Allocated,
                        },

                        new OrderDetailRecord
                        {
                            ProductRecordId = _productRecords[2].Id,
                            UnitPrice = _productRecords[2].ListPrice,
                            Quantity = 50,
                            OrderDetailStatusRecordId = (int)OrderItemStatus.Invoiced,
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

            Assert.True(createResponse.Id > 0);
            Assert.Equal(createRequest.CustomerId, createResponse.CustomerId);
            Assert.Equal((int)OrderStatus.New, createResponse.StatusId);

            Assert.NotNull(createResponse.OrderItems);

            Assert.Equal(createRequest.OrderItems.Count, createResponse.OrderItems.Count);

            for (int i = 0; i < createRequest.OrderItems.Count; i++)
            {
                var createRequestOrderDetail = createRequest.OrderItems[i];
                var createResponseOrderDetail = createResponse.OrderItems[i];

                Assert.True(createResponseOrderDetail.Id > 0);
                Assert.Equal(createRequestOrderDetail.ProductId, createResponseOrderDetail.ProductId);
                Assert.Equal(createRequestOrderDetail.Quantity, createResponseOrderDetail.Quantity);
                Assert.Equal((int)OrderItemStatus.Allocated, createResponseOrderDetail.StatusId);
            }

            var findRequest = new FindOrderRequest { Id = createResponse.Id };

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);
            var findResponse = findApiResponse.Data;

            Assert.Equal(createResponse.Id, findResponse.Id);
            Assert.Equal(createResponse.CustomerId, createResponse.CustomerId);
            Assert.Equal(createResponse.StatusId, createResponse.StatusId);

            Assert.NotNull(findResponse.OrderItems);

            Assert.Equal(createResponse.OrderItems.Count, findResponse.OrderItems.Count);

            for (int i = 0; i < createResponse.OrderItems.Count; i++)
            {
                var createResponseOrderDetail = createResponse.OrderItems[i];
                var findResponseOrderDetail = findResponse.OrderItems[i];

                Assert.Equal(createResponseOrderDetail.Id, findResponseOrderDetail.Id);
                Assert.Equal(createResponseOrderDetail.ProductId, findResponseOrderDetail.ProductId);
                Assert.Equal(createResponseOrderDetail.Quantity, findResponseOrderDetail.Quantity);
                Assert.Equal(createResponseOrderDetail.StatusId, findResponseOrderDetail.StatusId);
            }
        }

        [Fact(Skip = "In progress")]
        public async Task CreateOrder_InvalidRequest_ThrowsInvalidRequestException()
        {
            var createRequest = new CreateOrderRequest
            {
                CustomerId = 999,
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
            Assert.Equal(orderRecord.CustomerRecordId, findResponse.CustomerId);
            Assert.Equal(orderRecord.OrderStatusRecordId, findResponse.StatusId);

            Assert.NotNull(findResponse.OrderItems);

            Assert.Equal(orderRecord.OrderDetailRecords.Count, findResponse.OrderItems.Count);

            for (int i = 0; i < orderRecord.OrderDetailRecords.Count; i++)
            {
                var orderDetailRecord = orderRecord.OrderDetailRecords.ToList()[i];
                var findResponseDetail = findResponse.OrderItems[i];

                Assert.Equal(orderDetailRecord.Id, findResponseDetail.Id);
                Assert.Equal(orderDetailRecord.ProductRecordId, findResponseDetail.ProductId);
                Assert.Equal(orderDetailRecord.Quantity, findResponseDetail.Quantity);
                Assert.Equal(orderDetailRecord.OrderDetailStatusRecordId, findResponseDetail.StatusId);
            }
        }

        [Fact]
        public async Task FindOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

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

            var orderStatusId = orderRecord.OrderStatusRecordId;

            var updateRequest = new UpdateOrderRequest
            {
                Id = orderRecord.Id,
                OrderItems = new List<UpdateOrderItemRequest>
                {
                    new UpdateOrderItemRequest
                    {
                        Id = orderRecord.OrderDetailRecords.ElementAt(0).Id,
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
            Assert.Equal(orderRecord.CustomerRecordId, updateResponse.CustomerId);
            Assert.Equal(orderStatusId, updateResponse.StatusId);

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
                    Assert.True(updateResponseOrderDetail.Id > 0);
                }

                Assert.Equal(updateRequestOrderDetail.ProductId, updateResponseOrderDetail.ProductId);
                Assert.Equal(updateRequestOrderDetail.Quantity, updateResponseOrderDetail.Quantity);
                Assert.Equal((int)OrderItemStatus.Allocated, updateResponseOrderDetail.StatusId);
            }

            var findRequest = new FindOrderRequest { Id = updateResponse.Id };

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findApiResponse.StatusCode);

            var findResponse = findApiResponse.Data;

            Assert.Equal(updateResponse.Id, findResponse.Id);
            Assert.Equal(updateResponse.CustomerId, updateResponse.CustomerId);
            Assert.Equal(updateResponse.StatusId, updateResponse.StatusId);

            Assert.NotNull(findResponse.OrderItems);

            Assert.Equal(updateResponse.OrderItems.Count, findResponse.OrderItems.Count);

            for (int i = 0; i < updateResponse.OrderItems.Count; i++)
            {
                var updateResponseOrderDetail = updateResponse.OrderItems[i];
                var findResponseOrderDetail = findResponse.OrderItems[i];

                Assert.Equal(updateResponseOrderDetail.Id, findResponseOrderDetail.Id);
                Assert.Equal(updateResponseOrderDetail.ProductId, findResponseOrderDetail.ProductId);
                Assert.Equal(updateResponseOrderDetail.Quantity, findResponseOrderDetail.Quantity);
                Assert.Equal(updateResponseOrderDetail.StatusId, findResponseOrderDetail.StatusId);
            }
        }

        [Fact]
        public async Task UpdateOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var updateRequest = new UpdateOrderRequest
            {
                Id = 999,
                OrderItems = new List<UpdateOrderItemRequest>
                {
                    new UpdateOrderItemRequest
                    {
                        Id = 1,
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
