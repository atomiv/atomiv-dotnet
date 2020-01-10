using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Test.Xunit;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.IntegrationTest.Fixtures
{
    public class Test : FixtureTest<Fixture>, IDisposable
    {
        public Test(Fixture fixture)
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

        protected Task<IObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand createRequest)
        {
            return Fixture.Api.Customers.CreateCustomerAsync(createRequest);
        }

        protected Task<IObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand createRequest)
        {
            return Fixture.Api.Products.CreateProductAsync(createRequest);
        }
    }
}