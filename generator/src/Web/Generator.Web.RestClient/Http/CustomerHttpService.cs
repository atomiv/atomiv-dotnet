﻿using Atomiv.Core.Common.Http;
using Atomiv.Infrastructure.AspNetCore;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using Generator.Web.RestClient.Interface;
using System;
using System.Threading.Tasks;

namespace Generator.Web.RestClient.Http
{
    public class CustomerHttpService : BaseControllerClient, ICustomerHttpService
    {
        public CustomerHttpService(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/customers")
        {
        }

        public Task<IObjectClientResponse<BrowseCustomersResponse>> BrowseCustomersAsync(BrowseCustomersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return Client.PostAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<IObjectClientResponse<DeleteCustomerResponse>> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            var id = request.Id;
            return Client.DeleteByIdAsync<int, DeleteCustomerResponse>(id);
        }

        public Task<IObjectClientResponse<FindCustomerResponse>> FindCustomerAsync(FindCustomerRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<int, FindCustomerResponse>(id);
        }

        public Task<IObjectClientResponse<ListCustomersResponse>> ListCustomersAsync(ListCustomersRequest request)
        {
            return Client.GetAsync<ListCustomersResponse>();
        }

        public Task<IObjectClientResponse<UpdateCustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return Client.PutByIdAsync<int, UpdateCustomerRequest, UpdateCustomerResponse>(request.Id, request);
        }
    }
}
