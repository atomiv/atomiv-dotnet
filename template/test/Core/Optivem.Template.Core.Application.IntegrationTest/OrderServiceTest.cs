using Optivem.Template.Core.Application.IntegrationTest.Fixtures;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest
{
    public class OrderServiceTest : ServiceTest
    {
        private readonly List<CustomerRecord> _customerRecords;
        private readonly List<ProductRecord> _productRecords;
        private readonly List<OrderRecord> _orderRecords;

        public OrderServiceTest(ServiceFixture fixture) : base(fixture)
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
            };

            Fixture.Db.AddRange(_productRecords);


            _orderRecords = new List<OrderRecord>
            {
                new OrderRecord
                {
                    CustomerId = _customerRecords[0].Id,
                    StatusId = (int)OrderStatus.Invoiced,

                    OrderDetails = new List<OrderDetailRecord>
                    {
                        new OrderDetailRecord
                        {
                            ProductId = _productRecords[0].Id,
                            UnitPrice = _productRecords[0].ListPrice,
                            Quantity = 30,
                            StatusId = (int)OrderDetailStatus.NoStock,
                        },

                        new OrderDetailRecord
                        {
                            ProductId = _productRecords[1].Id,
                            UnitPrice = _productRecords[1].ListPrice,
                            Quantity = 60,
                            StatusId = (int)OrderDetailStatus.OnOrder,
                        },
                    },
                },

                new OrderRecord
                {
                    CustomerId = _customerRecords[1].Id,
                    StatusId = (int)OrderStatus.Shipped,

                    OrderDetails = new List<OrderDetailRecord>
                    {
                        new OrderDetailRecord
                        {
                            ProductId = _productRecords[1].Id,
                            UnitPrice = _productRecords[1].ListPrice,
                            Quantity = 40,
                            StatusId = (int)OrderDetailStatus.Allocated,
                        },
                    },
                },
            };

            Fixture.Db.AddRange(_orderRecords);
        }

        /*

        [Fact(Skip = "TODO")]
        public async Task BrowseOrders_ValidRequest_ReturnsResponse()
        {
            var browseRequest = new BrowseOrdersRequest { };

            var browseResponse = await Fixture.Orders.BrowseOrdersAsync(browseRequest);
        }



        [Fact]
        public async Task CreateOrder_ValidRequest_ReturnsResponse()
        {
            var createRequest = new CreateOrderRequest
            {
                CustomerId = 2,
                OrderDetails = new List<CreateOrderRequest.OrderDetail>
                {
                    new CreateOrderRequest.OrderDetail
                    {
                        ProductId = 501,
                        Quantity = 10,
                    },

                    new CreateOrderRequest.OrderDetail
                    {
                        ProductId = 600,
                        Quantity = 20,
                    }
                },
            };

            var createResponse = await Fixture.Orders.CreateOrderAsync(createRequest);

            Assert.True(createResponse.Id > 0);
            Assert.Equal(createRequest.CustomerId, createResponse.C);
            Assert.Equal(createRequest.LastName, createResponse.LastName);

            var findRequest = new FindOrderRequest { Id = createResponse.Id };

            var findResponse = await Fixture.Orders.FindOrderAsync(findRequest);

            Assert.Equal(findRequest.Id, findResponse.Id);
            Assert.Equal(createRequest.FirstName, findResponse.FirstName);
            Assert.Equal(createRequest.LastName, findResponse.LastName);
        }

        [Fact]
        public async Task CreateOrder_InvalidRequest_ThrowsInvalidRequestException()
        {
            var createRequest = new CreateOrderRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.Orders.CreateOrderAsync(createRequest));
        }

        [Fact]
        public async Task DeleteOrder_ValidRequest_ReturnsResponse()
        {
            var orderRecord = _orderRecords[0];
            var id = orderRecord.Id;

            var deleteRequest = new DeleteOrderRequest { Id = id };
            var deleteResponse = await Fixture.Orders.DeleteOrderAsync(deleteRequest);
        }

        [Fact]
        public async Task DeleteOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

            var deleteRequest = new DeleteOrderRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Orders.DeleteOrderAsync(deleteRequest));
        }

        */

        [Fact(Skip = "In progress")]
        public async Task FindOrder_ValidRequest_ReturnsOrder()
        {
            var orderRecord = _orderRecords[0];
            var id = orderRecord.Id;

            var findRequest = new FindOrderRequest { Id = id };
            var findResponse = await Fixture.Orders.FindOrderAsync(findRequest);

            Assert.Equal(orderRecord.Id, findResponse.Id);
            Assert.Equal(orderRecord.CustomerId, findResponse.CustomerId);
            Assert.Equal(orderRecord.StatusId, findResponse.StatusId);

            Assert.NotNull(orderRecord.OrderDetails);

            Assert.Equal(orderRecord.OrderDetails.Count, findResponse.OrderDetails.Count);

            for(int i = 0; i <= orderRecord.OrderDetails.Count; i++)
            {
                var orderDetailRecord = orderRecord.OrderDetails.ToList()[i];
                var findResponseDetail = findResponse.OrderDetails[i];

                Assert.Equal(orderDetailRecord.ProductId, findResponseDetail.ProductId);
                Assert.Equal(orderDetailRecord.Quantity, findResponseDetail.Quantity);
                Assert.Equal(orderDetailRecord.StatusId, findResponseDetail.StatusId);
            }
        }



        /*

        [Fact]
        public async Task FindOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

            var findRequest = new FindOrderRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Orders.FindOrderAsync(findRequest));
        }

        [Fact]
        public async Task ListOrders_ValidRequest_ReturnsResponse()
        {
            var request = new ListOrdersRequest();

            var actualResponse = await Fixture.Orders.ListOrdersAsync(request);

            Assert.Equal(_orderRecords.Count, actualResponse.Count);

            for (int i = 0; i < _orderRecords.Count; i++)
            {
                var expectedRecord = _orderRecords[i];
                var actualRecord = actualResponse.Records[i];

                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.FirstName, actualRecord.FirstName);
                Assert.Equal(expectedRecord.LastName, actualRecord.LastName);
            }
        }

        [Fact]
        public async Task UpdateOrder_ValidRequest_ReturnsResponse()
        {
            var orderRecord = _orderRecords[0];

            var updateRequest = new UpdateOrderRequest
            {
                Id = orderRecord.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Orders.UpdateOrderAsync(updateRequest);

            Assert.Equal(updateRequest.Id, updateResponse.Id);
            Assert.Equal(updateRequest.FirstName, updateResponse.FirstName);
            Assert.Equal(updateRequest.LastName, updateResponse.LastName);
        }

        [Fact]
        public async Task UpdateOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var orderRecord = _orderRecords[0];

            var updateRequest = new UpdateOrderRequest
            {
                Id = 999,
                FirstName = "New first name",
                LastName = "New last name",
            };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Orders.UpdateOrderAsync(updateRequest));
        }

        [Fact]
        public async Task UpdateOrder_InvalidRequest_ThrowsInvalidRequestException()
        {
            var orderRecord = _orderRecords[0];

            var updateRequest = new UpdateOrderRequest
            {
                Id = orderRecord.Id,
                FirstName = "New first name",
                LastName = null,
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.Orders.UpdateOrderAsync(updateRequest));
        }

    */
    }
}
