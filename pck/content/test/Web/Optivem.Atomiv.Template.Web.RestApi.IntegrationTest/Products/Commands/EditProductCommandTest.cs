using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Commands.Products;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Products.Commands
{
    public class EditProductCommandTest : BaseTest
    {
        public EditProductCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task UpdateProduct_Valid_OK()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createRequests = new List<CreateProductCommand>
            {
                new CreateProductCommand
                {
                    Code = "APP",
                    Description = "Apple",
                    UnitPrice = 10.50m,
                },

                new CreateProductCommand
                {
                    Code = "BAN",
                    Description = "Banana",
                    UnitPrice = 30.99m,
                },

                new CreateProductCommand
                {
                    Code = "ONG",
                    Description = "Orange",
                    UnitPrice = 35.99m,
                },

                new CreateProductCommand
                {
                    Code = "STR",
                    Description = "Strawberry",
                    UnitPrice = 40.00m,
                },
            };

            var createHttpResponses = await CreateProductsAsync(createRequests);

            var someCreateHttpResponse = createHttpResponses[2];
            var someCreateResponse = someCreateHttpResponse.Data;
            var id = someCreateResponse.Id;

            var updateRequest = new EditProductCommand
            {
                Id = id,
                Description = "New desc",
                UnitPrice = 130,
            };

            // Act

            var updateHttpResponse = await Fixture.Api.Products.EditProductAsync(updateRequest, header);

            // Assert

            updateHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updateResponse = updateHttpResponse.Data;

            updateResponse.Should().BeEquivalentTo(updateRequest);
        }

        [Fact]
        public async Task UpdateProduct_NotExist_NotFound()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var id = Guid.NewGuid();

            var updateRequest = new EditProductCommand
            {
                Id = id,
                Description = "New desc 2",
                UnitPrice = 140,
            };

            // Act

            var updateHttpResponse = await Fixture.Api.Products.EditProductAsync(updateRequest, header);

            // Assert

            updateHttpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateProduct_Invalid_UnprocessableEntity()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createRequests = new List<CreateProductCommand>
            {
                new CreateProductCommand
                {
                    Code = "APP",
                    Description = "Apple",
                    UnitPrice = 10.50m,
                },

                new CreateProductCommand
                {
                    Code = "BAN",
                    Description = "Banana",
                    UnitPrice = 30.99m,
                },

                new CreateProductCommand
                {
                    Code = "ONG",
                    Description = "Orange",
                    UnitPrice = 35.99m,
                },

                new CreateProductCommand
                {
                    Code = "STR",
                    Description = "Strawberry",
                    UnitPrice = 40.00m,
                },
            };

            var createHttpResponses = await CreateProductsAsync(createRequests);

            var someCreateHttpResponse = createHttpResponses[2];
            var someCreateResponse = someCreateHttpResponse.Data;
            var id = someCreateResponse.Id;

            var updateRequest = new EditProductCommand
            {
                Id = id,
                Description = "New desc 3",
                UnitPrice = -2,
            };

            // Act

            var updateResponse = await Fixture.Api.Products.EditProductAsync(updateRequest, header);

            // Assert

            updateResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);

            var problemDetails = updateResponse.ProblemDetails;

            problemDetails.Status.Should().Be((int)HttpStatusCode.UnprocessableEntity);
        }
    }
}
