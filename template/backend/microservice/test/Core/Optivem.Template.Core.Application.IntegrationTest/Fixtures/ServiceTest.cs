using Optivem.Framework.Test.Xunit;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.IntegrationTest.Fixtures
{
    public class ServiceTest : FixtureTest<ServiceFixture>, IDisposable
    {
        public ServiceTest(ServiceFixture fixture)
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

        protected async Task<List<CreateCustomerCommandResponse>> CreateCustomersAsync(IEnumerable<CreateCustomerCommand> createRequests)
        {
            var createResponses = new List<CreateCustomerCommandResponse>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateCustomerAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected async Task<List<CreateProductCommandResponse>> CreateProductsAsync(IEnumerable<CreateProductCommand> createRequests)
        {
            var createResponses = new List<CreateProductCommandResponse>();

            foreach (var createRequest in createRequests)
            {
                var createResponse = await CreateProductAsync(createRequest);
                createResponses.Add(createResponse);
            }

            return createResponses;
        }

        protected Task<CreateCustomerCommandResponse> CreateCustomerAsync(CreateCustomerCommand createRequest)
        {
            return Fixture.CustomerService.CreateCustomerAsync(createRequest);
        }

        protected Task<CreateProductCommandResponse> CreateProductAsync(CreateProductCommand createRequest)
        {
            return Fixture.ProductService.CreateProductAsync(createRequest);
        }
    }
}