using Optivem.Template.Core.Application.IntegrationTest.Fixtures;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Records;
using System.Collections.Generic;
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

        [Fact]
        public async Task TestListProducts()
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
