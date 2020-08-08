using Atomiv.Template.Core.Application.Commands.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Products.Commands
{
    public class SyncProductsCommandTest : BaseTest
    {
        public SyncProductsCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task SyncProducts_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createRequests = new List<CreateProductCommand>
            {
                new CreateProductCommand
                {
                    Code = $"APP{DateTime.Now}",
                    Description = "Apple",
                    UnitPrice = 10.50m,
                },

                new CreateProductCommand
                {
                    Code = $"BAN{DateTime.Now}",
                    Description = "Banana",
                    UnitPrice = 30.99m,
                },

                new CreateProductCommand
                {
                    Code = $"ONG{DateTime.Now}",
                    Description = "Orange",
                    UnitPrice = 35.99m,
                },

                new CreateProductCommand
                {
                    Code = $"STR{DateTime.Now}",
                    Description = "Strawberry",
                    UnitPrice = 40.00m,
                },
            };

            var createHttpResponses = await CreateProductsAsync(createRequests);

            // Act

            var syncRequest = new SyncProductsCommand();

            var syncHttpResponse = await Fixture.Api.Products.SyncProductsAsync(syncRequest, header);

            // Assert

            syncHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var expectedSyncResponse = new UnlistProductCommandResponse();

            var syncResponse = syncHttpResponse.Data;

            syncResponse.Should().BeEquivalentTo(expectedSyncResponse);
        }
    }
}
