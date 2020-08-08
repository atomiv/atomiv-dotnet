using FluentAssertions;
using Atomiv.Core.Common.Http;
using Atomiv.Test.Xunit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Atomiv.Template.Web.RestClient.Interface;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Commands.Products;

namespace Atomiv.Template.Web.RestApi.IntegrationTest
{
    public class BaseTest : FixtureTest<Fixture>, IDisposable
    {
        public BaseTest(Fixture fixture)
            : base(fixture)
        {
        }

        public void Dispose()
        {
        }

        protected async Task<List<ObjectClientResponse<CreateCustomerCommandResponse>>> CreateCustomersAsync(IEnumerable<CreateCustomerCommand> createRequests)
        {
            var createResponses = new List<ObjectClientResponse<CreateCustomerCommandResponse>>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateCustomerAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<List<ObjectClientResponse<CreateOrderCommandResponse>>> CreateOrdersAsync(IEnumerable<CreateOrderCommand> createRequests)
        {
            var createResponses = new List<ObjectClientResponse<CreateOrderCommandResponse>>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateOrderAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<List<ObjectClientResponse<CreateProductCommandResponse>>> CreateProductsAsync(IEnumerable<CreateProductCommand> createRequests)
        {
            var createResponses = new List<ObjectClientResponse<CreateProductCommandResponse>>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateProductAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<ObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var header = await GetDefaultHeaderDataAsync();
            var httpResponse = await Fixture.Api.Customers.CreateCustomerAsync(command, header);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            return httpResponse;
        }

        protected async Task<ObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand command)
        {
            var header = await GetDefaultHeaderDataAsync();
            var httpResponse = await Fixture.Api.Orders.CreateOrderAsync(command, header);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            return httpResponse;
        }

        protected async Task<ObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand command)
        {
            var header = await GetDefaultHeaderDataAsync();
            var httpResponse = await Fixture.Api.Products.CreateProductAsync(command, header);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            return httpResponse;
        }

        protected Task<List<ObjectClientResponse<CreateCustomerCommandResponse>>> CreateSampleCustomersAsync()
        {
            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary2",
                    LastName = "Smith2",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John2",
                    LastName = "McDonald2",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Jake2",
                    LastName = "McDonald2",
                }
            };

            return CreateCustomersAsync(createRequests);
        }

        protected async Task<List<ObjectClientResponse<CreateOrderCommandResponse>>> CreateSampleOrdersAsync()
        {
            var createCustomerResponses = await CreateSampleCustomersAsync();
            var createProductResponses = await CreateSampleProductsAsync();

            return await CreateSampleOrdersAsync(createCustomerResponses, createProductResponses);
        }

        protected Task<List<ObjectClientResponse<CreateOrderCommandResponse>>> CreateSampleOrdersAsync(List<ObjectClientResponse<CreateCustomerCommandResponse>> createCustomerResponses,
            List<ObjectClientResponse<CreateProductCommandResponse>> createProductResponses)
        {
            var customerId_0 = createCustomerResponses[0].Data.Id;
            var customerId_1 = createCustomerResponses[1].Data.Id;

            var productId_0 = createProductResponses[0].Data.Id;
            var productId_1 = createProductResponses[1].Data.Id;
            var productId_2 = createProductResponses[2].Data.Id;

            var createRequests = new List<CreateOrderCommand>
            {
                new CreateOrderCommand
                {
                    CustomerId = customerId_0,

                    OrderItems = new List<CreateOrderItemCommand>
                    {
                        new CreateOrderItemCommand
                        {
                            ProductId = productId_0,
                            Quantity = 30,
                        },

                        new CreateOrderItemCommand
                        {
                            ProductId = productId_1,
                            Quantity = 60,
                        },
                    },
                },

                new CreateOrderCommand
                {
                    CustomerId = customerId_1,

                    OrderItems = new List<CreateOrderItemCommand>
                    {
                        new CreateOrderItemCommand
                        {
                            ProductId = productId_1,
                            Quantity = 40,
                        },

                        new CreateOrderItemCommand
                        {
                            ProductId = productId_2,
                            Quantity = 50,
                        },
                    },
                },
            };

            return CreateOrdersAsync(createRequests);
        }

        protected Task<List<ObjectClientResponse<CreateProductCommandResponse>>> CreateSampleProductsAsync()
        {
            var createRequests = new List<CreateProductCommand>
            {
                new CreateProductCommand
                {
                    Code = $"APP2{DateTime.Now}",
                    Description = "Apple2",
                    UnitPrice = 102.50m,
                },

                new CreateProductCommand
                {
                    Code = $"BAN2{DateTime.Now}",
                    Description = "Banana2",
                    UnitPrice = 302.99m,
                },

                new CreateProductCommand
                {
                    Code = $"ORG2{DateTime.Now}",
                    Description = "Orange2",
                    UnitPrice = 102.50m,
                },

                new CreateProductCommand
                {
                    Code = $"MAN2{DateTime.Now}",
                    Description = "Mango2",
                    UnitPrice = 500.99m,
                },
            };

            return CreateProductsAsync(createRequests);
        }


        protected Task<HeaderData> GetDefaultHeaderDataAsync()
        {
            var result = new HeaderData
            {
                Token = "bde2080b-c50a-4ed6-a9b0-9a33ccdb1ab7",
                Language = "en",
            };

            return Task.FromResult(result);
        }
    }
}