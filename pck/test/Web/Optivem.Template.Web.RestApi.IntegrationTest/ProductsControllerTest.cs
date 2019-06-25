using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Records;
using Optivem.Template.Web.RestApi.IntegrationTest.Fixtures;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Web.RestApi.IntegrationTest
{
    public class ProductsControllerTest : ControllerTest
    {
        private List<ProductRecord> _productRecords;

        public ProductsControllerTest(ControllerFixture fixture) : base(fixture)
        {
            _productRecords = new List<ProductRecord>
            {
                // TODO: VC: Currency

                new ProductRecord
                {
                    ProductCode = "APP",
                    ProductName = "Apple",
                    ListPrice = 10.50m,
                },

                new ProductRecord
                {
                    ProductCode = "BAN",
                    ProductName = "Banana",
                    ListPrice = 30.99m,
                },
            };

            Fixture.Db.AddRange(_productRecords);
        }

        // TODO: VC: Naming conventions for tests

        [Fact(Skip = "Need to fix test")]
        public async Task BrowseProducts_OK()
        {
            for(int i = 0; i < 30; i++)
            {
                var productRecord = new ProductRecord
                {
                    ProductCode = $"P{i}",
                    ProductName = $"Product {i}",
                    ListPrice = 100 + i,
                };

                // TODO: VC: Check if valid
                _productRecords.Add(productRecord);

                Fixture.Db.Add(productRecord);
            }

            var browseRequest = new BrowseProductsRequest
            {
                Page = 3,
                Size = 5,
            };

            var browseResponse = await Fixture.Products.BrowseProductsAsync(browseRequest);

            Assert.Equal(HttpStatusCode.OK, browseResponse.StatusCode);

            var browseResponseContent = browseResponse.Data;

            Assert.Equal(browseRequest.Size, browseResponseContent.Count);

            var skip = browseRequest.Page * browseRequest.Size;
            var take = browseRequest.Size;

            var expected = _productRecords.Skip(skip).Take(take).ToList();

            for(int i = 0; i < expected.Count; i++)
            {
                var expectedRecord = expected[i];
                var actualRecord = browseResponseContent.Records[i];
                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.ProductCode, actualRecord.Code);
                Assert.Equal(expectedRecord.Id, actualRecord.UnitPrice);
            }
        }


        [Fact(Skip = "Pending implement")]
        public async Task CreateProduct_Invalid_MissingCode_UnprocessableEntity()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

            var createRequest = new CreateProductRequest
            {
                Code = null,
                Description = "My desc",
                UnitPrice = 112,
            };

            var createResponse = await Fixture.Products.CreateProductAsync(createRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            var problemDetails = createResponse.ProblemDetails;

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }



        [Fact]
        public async Task ListProducts_OK()
        {
            var actual = await Fixture.Products.ListProductsAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Data;

            Assert.Equal(2, actualContent.Records.Count);

            var expectedFirst = _productRecords[0];
            var actualFirst = actualContent.Records[0];

            Assert.True(actualFirst.Id > 0);
            Assert.Equal($"{expectedFirst.ProductCode} - {expectedFirst.ProductName}", actualFirst.Name);

            var expectedSecond = _productRecords[1];
            var actualSecond = actualContent.Records[1];

            Assert.True(actualSecond.Id > 0);
            Assert.Equal($"{expectedSecond.ProductCode} - {expectedSecond.ProductName}", actualSecond.Name);
        }

        [Fact(Skip = "Pending implement")]
        public async Task FindProduct_Valid_OK()
        {
            var productRecord = _productRecords[0];
            var id = productRecord.Id;

            var findResponse = await Fixture.Products.FindProductAsync(id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Data;

            Assert.Equal(productRecord.Id, findResponseContent.Id);
            Assert.Equal(productRecord.ProductCode, findResponseContent.Code);
            Assert.Equal(productRecord.ProductName, findResponseContent.Description);
            Assert.Equal(productRecord.ListPrice, findResponseContent.UnitPrice);
        }

        [Fact]
        public async Task FindProduct_NotExist_NotFound()
        {
            var id = 999;

            var findResponse = await Fixture.Products.FindProductAsync(id);

            Assert.Equal(HttpStatusCode.NotFound, findResponse.StatusCode);
        }

        [Fact(Skip = "Pending implement")]
        public async Task CreateProduct_Valid_Created()
        {
            var createRequest = new CreateProductRequest
            {
                Code = "My code 1",
                Description = "My name 1",
                UnitPrice = 100.56m,
            };

            var createResponse = await Fixture.Products.CreateProductAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.Code, createResponseContent.Code);
            Assert.Equal(createRequest.Description, createResponseContent.Description);
            Assert.Equal(createRequest.UnitPrice, createResponseContent.UnitPrice);

            var findResponse = await Fixture.Products.FindProductAsync(createResponseContent.Id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Data;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.Code, findResponseContent.Code);
            Assert.Equal(createRequest.Description, findResponseContent.Description);
            Assert.Equal(createRequest.UnitPrice, findResponseContent.UnitPrice);
        }



        [Fact(Skip = "Pending implement")]
        public async Task UpdateProduct_Valid_OK()
        {
            var productRecord = _productRecords[0];

            var updateRequest = new UpdateProductRequest
            {
                Id = productRecord.Id,
                Description = "New desc",
                UnitPrice = 130,
            };

            var updateResponse = await Fixture.Products.UpdateProductAsync(updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            var updateResponseContent = updateResponse.Data;

            Assert.Equal(updateRequest.Id, updateResponseContent.Id);
            Assert.Equal(updateRequest.Description, updateResponseContent.Description);
            Assert.Equal(updateRequest.UnitPrice, updateResponseContent.UnitPrice);

            // TODO: VC: Do another GET
        }

        [Fact]
        public async Task UpdateProduct_NotExist_NotFound()
        {
            var updateRequest = new UpdateProductRequest
            {
                Id = 999,
                Description = "New desc 2",
                UnitPrice = 140,
            };

            var updateResponse = await Fixture.Products.UpdateProductAsync(updateRequest);

            Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);

            // TODO: VC: Do GET to assert not updated
        }

        [Fact(Skip = "Pending implement")]
        public async Task UpdateProduct_Invalid_MissingCode_UnprocessableEntity()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

            var productRecord = _productRecords[0];

            var updateRequest = new UpdateProductRequest
            {
                Id = productRecord.Id,
                Description = "New desc 3",
                UnitPrice = 150,
            };

            var updateResponse = await Fixture.Products.UpdateProductAsync(updateRequest);
            Assert.Equal(HttpStatusCode.UnprocessableEntity, updateResponse.StatusCode);

            var problemDetails = updateResponse.ProblemDetails;
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        // TODO: VC: Test that DELETE is not possible
    }
}