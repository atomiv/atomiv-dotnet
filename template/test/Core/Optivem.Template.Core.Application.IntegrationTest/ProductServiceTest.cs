using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.IntegrationTest.Fixtures;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest
{
    public class ProductServiceTest : ServiceTest
    {
        private readonly List<ProductRecord> _productRecords;

        public ProductServiceTest(ServiceFixture client)
            : base(client)
        {
            _productRecords = new List<ProductRecord>
            {
                new ProductRecord
                {
                    ProductCode = "APP",
                    ProductName = "Apple",
                    ListPrice = 10.50m,
                    IsActive = true,
                },

                new ProductRecord
                {
                    ProductCode = "BAN",
                    ProductName = "Banana",
                    ListPrice = 30.99m,
                    IsActive = true,
                },

                new ProductRecord
                {
                    ProductCode = "ONG",
                    ProductName = "Orange",
                    ListPrice = 35.99m,
                    IsActive = false,
                },

                new ProductRecord
                {
                    ProductCode = "STR",
                    ProductName = "Strawberry",
                    ListPrice = 40.00m,
                    IsActive = true,
                },
            };

            Fixture.Db.AddRange(_productRecords);

        }

        [Fact]
        public async Task ActivateProduct_ValidRequest_ReturnsResponse()
        {
            var record = _productRecords.Where(e => !e.IsActive).First();
            var id = record.Id;

            var activateRequest = new ActivateProductRequest
            {
                Id = id,
            };

            var activateResponse = await Fixture.Products.ActivateProductAsync(activateRequest);

            Assert.True(activateResponse.Id > 0);
            Assert.Equal(record.Id, activateResponse.Id);
            Assert.Equal(record.ProductCode, activateResponse.Code);
            Assert.Equal(record.ProductName, activateResponse.Description);
            Assert.Equal(record.ListPrice, activateResponse.UnitPrice);
            Assert.True(activateResponse.IsActive);

            var findRequest = new FindProductRequest { Id = activateResponse.Id };

            var findResponse = await Fixture.Products.FindProductAsync(findRequest);

            Assert.Equal(activateResponse.Id, findResponse.Id);
            Assert.Equal(activateResponse.Code, findResponse.Code);
            Assert.Equal(activateResponse.Description, findResponse.Description);
            Assert.Equal(activateResponse.UnitPrice, findResponse.UnitPrice);
            Assert.Equal(activateResponse.IsActive, findResponse.IsActive);
        }

        [Fact]
        public async Task ActivateProduct_InvalidRequest_ThrowsInvalidRequestException()
        {
            var record = _productRecords.Where(e => e.IsActive).First();
            var id = record.Id;

            var activateRequest = new ActivateProductRequest
            {
                Id = id,
            };

            await Assert.ThrowsAsync<ApplicationException>(() => Fixture.Products.ActivateProductAsync(activateRequest));
        }

        [Fact]
        public async Task BrowseProducts_ValidRequest_ReturnsResponse()
        {
            for (int i = 0; i < 30; i++)
            {
                var productRecord = new ProductRecord
                {
                    ProductCode = $"P{i}",
                    ProductName = $"Product {i}",
                    ListPrice = 100 + i,
                };

                _productRecords.Add(productRecord);

                Fixture.Db.Add(productRecord);
            }

            var browseRequest = new BrowseProductsRequest
            {
                Page = 3,
                Size = 5,
            };

            var browseResponse = await Fixture.Products.BrowseProductsAsync(browseRequest);

            Assert.Equal(browseRequest.Size, browseResponse.Count);

            var skip = browseRequest.Page * browseRequest.Size;
            var take = browseRequest.Size;

            var expected = _productRecords.Skip(skip).Take(take).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                var expectedRecord = expected[i];
                var actualRecord = browseResponse.Records[i];
                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.ProductCode, actualRecord.Code);
                Assert.Equal(expectedRecord.ProductName, actualRecord.Description);
                Assert.Equal(expectedRecord.ListPrice, actualRecord.UnitPrice);
            }
        }

        [Fact]
        public async Task CreateProduct_ValidRequest_ReturnsResponse()
        {
            var createRequest = new CreateProductRequest
            {
                Code = "ABC",
                Description = "My desc",
                UnitPrice = 123.56m,
            };

            var createResponse = await Fixture.Products.CreateProductAsync(createRequest);

            Assert.True(createResponse.Id > 0);
            Assert.Equal(createRequest.Code, createResponse.Code);
            Assert.Equal(createRequest.Description, createResponse.Description);
            Assert.Equal(createRequest.UnitPrice, createResponse.UnitPrice);

            var findRequest = new FindProductRequest { Id = createResponse.Id };

            var findResponse = await Fixture.Products.FindProductAsync(findRequest);

            Assert.Equal(findRequest.Id, findResponse.Id);
            Assert.Equal(createRequest.Code, findResponse.Code);
            Assert.Equal(createRequest.Description, findResponse.Description);
            Assert.Equal(createRequest.UnitPrice, findResponse.UnitPrice);
        }

        [Fact]
        public async Task CreateProduct_InvalidRequest_ThrowsInvalidRequestException()
        {
            var createRequest = new CreateProductRequest
            {
                Code = null,
                Description = "Something",
                UnitPrice = 123,
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.Products.CreateProductAsync(createRequest));
        }

        [Fact]
        public async Task DeactivateProduct_ValidRequest_ReturnsResponse()
        {
            var record = _productRecords.Where(e => e.IsActive).First();
            var id = record.Id;

            var dectivateRequest = new DeactivateProductRequest
            {
                Id = id,
            };

            var deactivateResponse = await Fixture.Products.DeactivateProductAsync(dectivateRequest);

            Assert.True(deactivateResponse.Id > 0);
            Assert.Equal(record.Id, deactivateResponse.Id);
            Assert.Equal(record.ProductCode, deactivateResponse.Code);
            Assert.Equal(record.ProductName, deactivateResponse.Description);
            Assert.Equal(record.ListPrice, deactivateResponse.UnitPrice);
            Assert.False(deactivateResponse.IsActive);

            var findRequest = new FindProductRequest { Id = deactivateResponse.Id };

            var findResponse = await Fixture.Products.FindProductAsync(findRequest);

            Assert.Equal(deactivateResponse.Id, findResponse.Id);
            Assert.Equal(deactivateResponse.Code, findResponse.Code);
            Assert.Equal(deactivateResponse.Description, findResponse.Description);
            Assert.Equal(deactivateResponse.UnitPrice, findResponse.UnitPrice);
            Assert.Equal(deactivateResponse.IsActive, findResponse.IsActive);
        }

        [Fact]
        public async Task DectivateProduct_InvalidRequest_ThrowsInvalidRequestException()
        {
            var record = _productRecords.Where(e => !e.IsActive).First();
            var id = record.Id;

            var deactivateRequest = new DeactivateProductRequest
            {
                Id = id,
            };

            await Assert.ThrowsAsync<ApplicationException>(() => Fixture.Products.DeactivateProductAsync(deactivateRequest));
        }

        [Fact]
        public async Task FindProduct_ValidRequest_ReturnsCustomer()
        {
            var customerRecord = _productRecords[0];
            var id = customerRecord.Id;

            var findRequest = new FindProductRequest { Id = id };
            var findResponse = await Fixture.Products.FindProductAsync(findRequest);

            Assert.Equal(customerRecord.Id, findResponse.Id);
            Assert.Equal(customerRecord.ProductCode, findResponse.Code);
            Assert.Equal(customerRecord.ProductName, findResponse.Description);
            Assert.Equal(customerRecord.ListPrice, findResponse.UnitPrice);
        }

        [Fact]
        public async Task FindProduct_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

            var findRequest = new FindProductRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Products.FindProductAsync(findRequest));
        }

        [Fact]
        public async Task ListProducts_ValidRequest_ReturnsResponse()
        {
            var request = new ListProductsRequest
            {

            };

            var response = await Fixture.Products.ListProductsAsync(request);

            Assert.Equal(_productRecords.Count, response.Count);

            for(int i = 0; i < _productRecords.Count; i++)
            {
                var expected = _productRecords[i];
                var actual = response.Records[i];

                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal($"{expected.ProductCode} - {expected.ProductName}", actual.Name);
            }

            Assert.NotNull(response);
        }


    }
}
