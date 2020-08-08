using FluentAssertions;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Application.Queries.Products;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Products.Commands
{
    public class RelistProductCommandTest : BaseTest
    {
        public RelistProductCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task RelistProduct_ValidRequest_ReturnsResponse()
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

            var someCreateHttpResponse = createHttpResponses[2];
            var someCreateResponse = someCreateHttpResponse.Data;
            var id = someCreateResponse.Id;

            var unlistRequest = new UnlistProductCommand { Id = id };
            var unlistHttpResponse = await Fixture.Api.Products.UnlistProductAsync(unlistRequest, header);

            unlistHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var expectedUnlistResponse = new UnlistProductCommandResponse
            {
                Id = id,
                IsListed = false,
            };

            var unlistResponse = unlistHttpResponse.Data;

            unlistResponse.Should().BeEquivalentTo(expectedUnlistResponse);

            // Act

            var relistRequest = new RelistProductCommand { Id = id };
            var relistHttpResponse = await Fixture.Api.Products.RelistProductAsync(relistRequest, header);

            // Assert

            var expectedRelistResponse = new RelistProductCommandResponse
            {
                Id = id,
                IsListed = true,
            };

            var relistResponse = relistHttpResponse.Data;

            relistResponse.Should().BeEquivalentTo(expectedRelistResponse);

            var findRequest = new ViewProductQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Products.ViewProductAsync(findRequest, header);

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(someCreateResponse);
        }
    }
}
