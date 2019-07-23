using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Application.Customers.Services;
using Optivem.Template.Web.RestClient.Http.Interface;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(IHttpCustomerService service)
        {
            Service = service;
        }

        public IHttpCustomerService Service { get; }

        public Task<BrowseCustomersResponse> BrowseCustomersAsync(BrowseCustomersRequest request)
        {
            return ExecuteAsync(e => e.BrowseCustomersAsync(request));
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return ExecuteAsync(e => e.CreateCustomerAsync(request));
        }

        public Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            return ExecuteAsync(e => e.DeleteCustomerAsync(request));
        }

        public Task<FindCustomerResponse> FindCustomerAsync(FindCustomerRequest request)
        {
            return ExecuteAsync(e => e.FindCustomerAsync(request));
        }

        public Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request)
        {
            return ExecuteAsync(e => e.ListCustomersAsync(request));
        }

        public Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return ExecuteAsync(e => e.UpdateCustomerAsync(request));
        }

        // TODO: VC: Create base HttpService class with this method and with holding the service, also for DI

        protected async Task<TResponse> ExecuteAsync<TResponse>(Func<IHttpCustomerService, Task<IObjectClientResponse<TResponse>>> action)
        {
            var response = await action(Service);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.Data;
        }
    }
}
