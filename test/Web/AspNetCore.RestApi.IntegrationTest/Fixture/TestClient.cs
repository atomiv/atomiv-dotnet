﻿using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Test.AspNetCore;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fixture
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
            return Client.GetByIdNoResponseAsync(id);
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
            var headers = new List<RequestHeader>
            {
                new RequestHeader(HttpRequestHeader.Accept.ToString(), "text/csv"),
            };

            // TODO: VC: Returning raw...
            return Client.GetAsync("exports", headers);
        }

        public Task<IClientResponse> PostImportsAsync(string content)
        {
            var headers = new List<RequestHeader>
            {
                new RequestHeader(HttpRequestHeader.ContentType.ToString(), "text/csv"),
                new RequestHeader(HttpRequestHeader.Accept.ToString(), "application/json"),
            };

            return Client.PostAsync("imports", content, headers);
        }

        public Task<IObjectClientResponse<CustomerPostResponse>> PostAsync(CustomerPostRequest request)
        {
            return Client.PostAsync<CustomerPostRequest, CustomerPostResponse>(request);
        }
    }
}