using Optivem.Atomiv.Template.Web.RestApi.IntegrationTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Products.Queries
{
    public class BrowseProductsQueryTest : BaseTest
    {
        public BrowseProductsQueryTest(Fixture fixture) : base(fixture)
        {
        }

        /*
         * 
        [Fact(Skip = "In progress")]
        public async Task BrowseProducts_Valid_OK()
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

            var browseRequest = new BrowseProductsQuery
            {
                Page = 3,
                Size = 5,
            };

            var browseResponse = await Fixture.Api.Products.BrowseProductsAsync(browseRequest);

            Assert.Equal(HttpStatusCode.OK, browseResponse.StatusCode);

            var browseResponseContent = browseResponse.Data;

            Assert.Equal(browseRequest.Size, browseResponseContent.TotalRecords);

            var skip = browseRequest.Page * browseRequest.Size;
            var take = browseRequest.Size;

            var expected = _productRecords.Skip(skip).Take(take).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                var expectedRecord = expected[i];
                var actualRecord = browseResponseContent.Records[i];
                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.ProductCode, actualRecord.Code);
                Assert.Equal(expectedRecord.ProductName, actualRecord.Description);
                Assert.Equal(expectedRecord.ListPrice, actualRecord.UnitPrice);
            }
        }
         * 
         */
    }
}
