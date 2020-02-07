using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using Optivem.Atomiv.Template.Core.Common.Orders;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Orders.Commands
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

            var createResponses = await CreateSampleOrdersAsync();
            var someCreateResponse = createResponses[1];

            // Act

            var id = someCreateResponse.Data.Id;
            var archiveRequest = new ArchiveOrderCommand { Id = id };
            var archiveHttpResponse = await Fixture.Api.Orders.ArchiveOrderAsync(archiveRequest);

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
            var findHttpResponse = await Fixture.Api.Orders.ViewOrderAsync(findRequest);

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(archiveResponse);
        }
    }
}
