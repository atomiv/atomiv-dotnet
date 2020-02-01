using Optivem.Atomiv.Template.Web.RestApi.IntegrationTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Products.Queries
{
    public class FilterProductsQueryTest : BaseTest
    {
        public FilterProductsQueryTest(Fixture fixture) : base(fixture)
        {
        }

        /*
         * 

        [Fact(Skip = "In progress")]
        public async Task ListProducts_Valid_OK()
        {
            var listRequest = new FilterProductsQuery { };

            var actual = await Fixture.Api.Products.FilterProductsAsync(listRequest);

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Data;

            Assert.Equal(2, actualContent.Records.Count);

            var expectedFirst = _productRecords[0];
            var actualFirst = actualContent.Records[0];

            AssertUtilities.NotEmpty(actualFirst.Id);
            Assert.Equal($"{expectedFirst.ProductCode} - {expectedFirst.ProductName}", actualFirst.Name);

            var expectedSecond = _productRecords[1];
            var actualSecond = actualContent.Records[1];

            AssertUtilities.NotEmpty(actualSecond.Id);
            Assert.Equal($"{expectedSecond.ProductCode} - {expectedSecond.ProductName}", actualSecond.Name);
        }
         * 
         */
    }
}
