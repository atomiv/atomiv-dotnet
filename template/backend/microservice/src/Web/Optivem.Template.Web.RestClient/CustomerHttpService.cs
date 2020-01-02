using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient
{
    public class CustomerHttpService : BaseControllerClient, ICustomerHttpService
    {
        public CustomerHttpService(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/customers")
        {
        }

        public Task<IObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request)
        {
            return Client.PostAsync<CreateCustomerCommand, CreateCustomerCommandResponse>(request);
        }

        public Task<IObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request)
        {
            var id = request.Id;
            return Client.DeleteByIdAsync<Guid, DeleteCustomerCommandResponse>(id);
        }

        public Task<IObjectClientResponse<FindCustomerQueryResponse>> FindCustomerAsync(FindCustomerQuery request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<Guid, FindCustomerQueryResponse>(id);
        }

        public Task<IObjectClientResponse<ListCustomersQueryResponse>> ListCustomersAsync(ListCustomersQuery request)
        {
            return Client.GetAsync<ListCustomersQueryResponse>();
        }

        public Task<IObjectClientResponse<UpdateCustomerCommandResponse>> UpdateCustomerAsync(UpdateCustomerCommand request)
        {
            return Client.PutByIdAsync<Guid, UpdateCustomerCommand, UpdateCustomerCommandResponse>(request.Id, request);
        }
    }
}