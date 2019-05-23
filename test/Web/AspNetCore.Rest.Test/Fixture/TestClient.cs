using Microsoft.Extensions.Configuration;
using Optivem.Common.Http;
using Optivem.Framework.Test.Web.AspNetCore.Rest.Fake;
using Optivem.Infrastructure.Http.System;
using Optivem.Test.Xunit.AspNetCore;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Web.AspNetCore.Test
{
    public class TestClient : BaseTestClient<Startup>
    {
        public TestClient()
        {
            Values = new ValuesControllerClient(ControllerClientFactory);
            Exceptions = new ExceptionsControllerClient(ControllerClientFactory);
            Customers = new CustomersControllerClient(ControllerClientFactory);
        }

        public ValuesControllerClient Values { get; }

        public ExceptionsControllerClient Exceptions { get; }

        public CustomersControllerClient Customers { get; }

        protected override string GetConfigurationJsonFile()
        {
            return null;
        }
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