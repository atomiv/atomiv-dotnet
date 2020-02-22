using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Products.Queries
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

            var createProductResponses = new List<CreateProductCommandResponse>();

            for (int i = 1; i <= 30; i++)
            {
                var createProductRequest = new CreateProductCommand
                {
                    Code = $"P{i}",
                    Description = $"Product {i}",
                    UnitPrice = 100 + i,
                };

                var createProductHttpResponse = await Fixture.Api.Products.CreateProductAsync(createProductRequest);

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

            var browseHttpResponse = await Fixture.Api.Products.BrowseProductsAsync(browseRequest);

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
