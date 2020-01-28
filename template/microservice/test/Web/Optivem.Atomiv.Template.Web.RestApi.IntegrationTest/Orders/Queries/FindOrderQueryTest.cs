using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Orders.Queries
{
    public class FindOrderQueryTest : BaseTest
    {
        public FindOrderQueryTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task FindOrder_ValidRequest_ReturnsOrder()
        {
            // Arrange

            var createHttpResponses = await CreateSampleOrdersAsync();

            var createResponse = createHttpResponses[0].Data;
            var id = createResponse.Id;

            // Act

            var findRequest = new FindOrderQuery { Id = id };

            var findHttpResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

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

            var findRequest = new FindOrderQuery { Id = id };

            // Act

            var findApiResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            // Assert

            findApiResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
