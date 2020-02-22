using FluentAssertions;
using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Test.Xunit;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest
{
    public class BaseTest : FixtureTest<Fixture>, IDisposable
    {
        public BaseTest(Fixture fixture)
            : base(fixture)
        {
        }

        public void Dispose()
        {
            using (var context = Fixture.Db.CreateContext())
            {
                context.Customers.RemoveRange(context.Customers);
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();
            }
        }

        protected async Task<List<IObjectClientResponse<CreateCustomerCommandResponse>>> CreateCustomersAsync(IEnumerable<CreateCustomerCommand> createRequests)
        {
            var createResponses = new List<IObjectClientResponse<CreateCustomerCommandResponse>>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateCustomerAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<List<IObjectClientResponse<CreateOrderCommandResponse>>> CreateOrdersAsync(IEnumerable<CreateOrderCommand> createRequests)
        {
            var createResponses = new List<IObjectClientResponse<CreateOrderCommandResponse>>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateOrderAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<List<IObjectClientResponse<CreateProductCommandResponse>>> CreateProductsAsync(IEnumerable<CreateProductCommand> createRequests)
        {
            var createResponses = new List<IObjectClientResponse<CreateProductCommandResponse>>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateProductAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<IObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var httpResponse = await Fixture.Api.Customers.CreateCustomerAsync(command);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            return httpResponse;
        }

        protected async Task<IObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand command)
        {
            var httpResponse = await Fixture.Api.Orders.CreateOrderAsync(command);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            return httpResponse;
        }

        protected async Task<IObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand command)
        {
            var httpResponse = await Fixture.Api.Products.CreateProductAsync(command);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            return httpResponse;
        }

        protected Task<List<IObjectClientResponse<CreateCustomerCommandResponse>>> CreateSampleCustomersAsync()
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

        protected async Task<List<IObjectClientResponse<CreateOrderCommandResponse>>> CreateSampleOrdersAsync()
        {
            var createCustomerResponses = await CreateSampleCustomersAsync();
            var createProductResponses = await CreateSampleProductsAsync();

            return await CreateSampleOrdersAsync(createCustomerResponses, createProductResponses);
        }

        protected Task<List<IObjectClientResponse<CreateOrderCommandResponse>>> CreateSampleOrdersAsync(List<IObjectClientResponse<CreateCustomerCommandResponse>> createCustomerResponses,
            List<IObjectClientResponse<CreateProductCommandResponse>> createProductResponses)
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

        protected Task<List<IObjectClientResponse<CreateProductCommandResponse>>> CreateSampleProductsAsync()
        {
            var createRequests = new List<CreateProductCommand>
            {
                new CreateProductCommand
                {
                    Code = "APP2",
                    Description = "Apple2",
                    UnitPrice = 102.50m,
                },

                new CreateProductCommand
                {
                    Code = "BAN2",
                    Description = "Banana2",
                    UnitPrice = 302.99m,
                },

                new CreateProductCommand
                {
                    Code = "ORG2",
                    Description = "Orange2",
                    UnitPrice = 102.50m,
                },

                new CreateProductCommand
                {
                    Code = "MAN2",
                    Description = "Mango2",
                    UnitPrice = 500.99m,
                },
            };

            return CreateProductsAsync(createRequests);
        }


        /*
         * 





         * 
         */

    }
}