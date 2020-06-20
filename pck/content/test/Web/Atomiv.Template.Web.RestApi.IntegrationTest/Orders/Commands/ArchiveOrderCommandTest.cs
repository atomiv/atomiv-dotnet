using FluentAssertions;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Core.Common.Orders;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Orders.Commands
{
    public class ArchiveOrderCommandTest : BaseTest
    {
        public ArchiveOrderCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ArchiveOrder_Valid()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createResponses = await CreateSampleOrdersAsync();
            var someCreateResponse = createResponses[1];

            // Act

            var id = someCreateResponse.Data.Id;
            var archiveRequest = new ArchiveOrderCommand { Id = id };
            var archiveHttpResponse = await Fixture.Api.Orders.ArchiveOrderAsync(archiveRequest, header);

            // Assert

            archiveHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var archiveResponse = archiveHttpResponse.Data;

            var expectedArchiveResponse = new ArchiveOrderCommandResponse
            {
                Id = id,
                Status = OrderStatus.Archived,
            };

            archiveResponse.Should().BeEquivalentTo(expectedArchiveResponse);

            var findRequest = new ViewOrderQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Orders.ViewOrderAsync(findRequest, header);

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(archiveResponse);
        }
    }
}
