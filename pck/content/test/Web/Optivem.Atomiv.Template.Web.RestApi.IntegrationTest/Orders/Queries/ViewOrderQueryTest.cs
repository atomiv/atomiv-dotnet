using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Orders.Queries
{
    public class ViewOrderQueryTest : BaseTest
    {
        public ViewOrderQueryTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ViewOrder_ValidRequest_ReturnsOrder()
        {
            // Arrange

            var createHttpResponses = await CreateSampleOrdersAsync();

            var createResponse = createHttpResponses[0].Data;
            var id = createResponse.Id;

            // Act

            var findRequest = new ViewOrderQuery { Id = id };

            var findHttpResponse = await Fixture.Api.Orders.ViewOrderAsync(findRequest);

            // Assert

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(createResponse);
        }

        [Fact]
        public async Task FindOrder_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // Arrange

            var id = Guid.NewGuid();

            var findRequest = new ViewOrderQuery { Id = id };

            // Act

            var findApiResponse = await Fixture.Api.Orders.ViewOrderAsync(findRequest);

            // Assert

            findApiResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
