using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using Optivem.Atomiv.Template.Core.Common.Orders;
using Optivem.Atomiv.Template.Web.RestApi.IntegrationTest;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var findRequest = new FindOrderQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Orders.FindOrderAsync(findRequest);

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(archiveResponse);
        }
    }
}
