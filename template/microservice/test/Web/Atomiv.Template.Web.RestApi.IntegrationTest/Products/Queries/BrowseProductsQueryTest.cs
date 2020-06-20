using FluentAssertions;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Application.Queries.Products;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Products.Queries
{
    public class BrowseProductsQueryTest : BaseTest
    {
        public BrowseProductsQueryTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task BrowseProducts_Valid_OK()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createProductResponses = new List<CreateProductCommandResponse>();

            for (int i = 1; i <= 30; i++)
            {
                var createProductRequest = new CreateProductCommand
                {
                    Code = $"P{i}",
                    Description = $"Product {i}",
                    UnitPrice = 100 + i,
                };

                var createProductHttpResponse = await Fixture.Api.Products.CreateProductAsync(createProductRequest, header);

                createProductHttpResponse.StatusCode.Should().Be(HttpStatusCode.Created);

                var createProductResponse = createProductHttpResponse.Data;

                createProductResponses.Add(createProductResponse);
            }

            var browseRequest = new BrowseProductsQuery
            {
                Page = 3,
                Size = 5,
            };

            // Act

            var browseHttpResponse = await Fixture.Api.Products.BrowseProductsAsync(browseRequest, header);

            // Assert

            browseHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // TODO: VC: Align with Hangfire synchronization

            /*
            var browseResponse = browseHttpResponse.Data;

            // TODO: VC: Check
            // browseResponse.TotalRecords.Should().Be(browseRequest.Size);

            var expected = createProductResponses.Skip(10).Take(5).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                var expectedRecord = expected[i];
                var actualRecord = browseResponse.Records[i];

                actualRecord.Should().BeEquivalentTo(expectedRecord);
            }
            */
        }
    }
}
