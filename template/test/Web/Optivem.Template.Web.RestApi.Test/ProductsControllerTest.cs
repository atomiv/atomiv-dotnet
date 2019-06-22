using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using Optivem.Template.Web.Test.Fixture;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

// TODO: VC: Consider moving to base
// [assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Optivem.Template.Web.Test
{
    public class ProductsControllerTest : TestFixture
    {
        private List<ProductRecord> _productRecords;

        public ProductsControllerTest(TestClient client) : base(client)
        {

        }

        protected override void Startup()
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

            Fixture.AddRange(_productRecords);
        }

        [Fact(Skip = "Pending implement")]
        public async Task ListProducts_OK()
        {
            var actual = await Fixture.Products.ListProductsAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Content;

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

            var findResponseContent = findResponse.Content;

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

            var createResponseContent = createResponse.Content;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.Code, createResponseContent.Code);
            Assert.Equal(createRequest.Description, createResponseContent.Description);
            Assert.Equal(createRequest.UnitPrice, createResponseContent.UnitPrice);

            var findResponse = await Fixture.Products.FindProductAsync(createResponseContent.Id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Content;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.Code, findResponseContent.Code);
            Assert.Equal(createRequest.Description, findResponseContent.Description);
            Assert.Equal(createRequest.UnitPrice, findResponseContent.UnitPrice);
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

            var createResponseContent = createResponse.Content;

            var problemDetails = createResponse.ProblemDetails;

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
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

            var updateResponseContent = updateResponse.Content;

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