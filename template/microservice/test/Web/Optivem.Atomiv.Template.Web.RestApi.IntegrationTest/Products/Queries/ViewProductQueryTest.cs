using Optivem.Atomiv.Template.Web.RestApi.IntegrationTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Products.Queries
{
    public class ViewProductQueryTest : BaseTest
    {
        public ViewProductQueryTest(Fixture fixture) : base(fixture)
        {
        }

        /*
         * 
        [Fact(Skip = "Pending implement")]
        public async Task FindProduct_Valid_OK()
        {
            var productRecord = _productRecords[0];
            var id = productRecord.Id;

            var findRequest = new ViewProductQuery { Id = id };

            var findResponse = await Fixture.Api.Products.ViewProductAsync(findRequest);

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
            var id = Guid.NewGuid();

            var findRequest = new ViewProductQuery { Id = id };

            var findResponse = await Fixture.Api.Products.ViewProductAsync(findRequest);

            Assert.Equal(HttpStatusCode.NotFound, findResponse.StatusCode);
        }
         * 
         */
    }
}
