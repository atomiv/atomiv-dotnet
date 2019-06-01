using Optivem.Common.Http;
using Optivem.Framework.Test.Web.AspNetCore.Rest.Fake;
using Optivem.Infrastructure.AspNetCore;
using Optivem.Test.AspNetCore;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Web.AspNetCore.Test
{
    public class TestClient
    {
        private readonly WebTestClient _client;

        public TestClient()
        {
            _client = WebTestClientFactory.Create<Startup>();
            var controllerClientFactory = _client.ControllerClientFactory;

            Values = new ValuesControllerClient(controllerClientFactory);
            Exceptions = new ExceptionsControllerClient(controllerClientFactory);
            Customers = new CustomersControllerClient(controllerClientFactory);
        }

        public ValuesControllerClient Values { get; }

        public ExceptionsControllerClient Exceptions { get; }

        public CustomersControllerClient Customers { get; }
    }

    public class ValuesControllerClient : BaseControllerClient
    {
        public ValuesControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/values")
        {
        }

        public Task<IObjectClientResponse<List<string>>> GetAllAsync()
        {
            return Client.GetAsync<List<string>>();
        }
    }

    public class ExceptionsControllerClient : BaseControllerClient
    {
        public ExceptionsControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/exceptions")
        {
        }

        public Task<IClientResponse> GetAsync(int id)
        {
            return Client.GetByIdAsync(id);
        }
    }

    public class CustomersControllerClient : BaseControllerClient
    {
        public CustomersControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/customers")
        {
        }

        public Task<IObjectClientResponse<CustomerGetAllResponse>> GetAllAsync()
        {
            return Client.GetAsync<CustomerGetAllResponse>();
        }

        public Task<IClientResponse> GetCsvExportsAsync()
        {
            // TODO: VC: Returning raw...
            return Client.GetAsync("exports", "text/csv");
        }

        public Task<IClientResponse> PostImportsAsync(string content)
        {
            return Client.PostAsync("imports", content, "text/csv", "application/json");
        }

        public Task<IObjectClientResponse<CustomerPostResponse>> PostAsync(CustomerPostRequest request)
        {
            return Client.PostAsync<CustomerPostRequest, CustomerPostResponse>(request);
        }
    }
}