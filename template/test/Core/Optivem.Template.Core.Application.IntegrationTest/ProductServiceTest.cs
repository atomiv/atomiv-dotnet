using Microsoft.Extensions.DependencyInjection;
using Optivem.Template.Core.Application.IntegrationTest.Fixture;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using Optivem.Test.Common.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest
{
    public class ProductServiceTest : ServiceTest
    {
        private readonly IProductService _productService;

        private readonly List<ProductRecord> _productRecords;

        public ProductServiceTest(ServiceFixture client)
            : base(client)
        {
            var configuration = ConfigurationRootFactory.Create();

            var services = new ServiceCollection();
            services.AddModules(configuration);

            var serviceProvider = services.BuildServiceProvider();

            _productService = serviceProvider.GetService<IProductService>();

            // TODO: DISPOSE
            // var serviceProvider.Dispose(); 

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

            var response = await _productService.ListProductsAsync(request);

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
