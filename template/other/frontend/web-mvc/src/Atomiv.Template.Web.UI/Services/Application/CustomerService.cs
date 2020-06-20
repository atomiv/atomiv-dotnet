using Atomiv.Infrastructure.AspNetCore;
using Atomiv.Template.Core.Application.Customers;
using Atomiv.Template.Core.Application.Customers.Requests;
using Atomiv.Template.Core.Application.Customers.Responses;
using Atomiv.Template.Web.RestClient.Interface;
using System.Threading.Tasks;

namespace Atomiv.Template.Web.UI.Services.Application
{
    public class CustomerService : BaseHttpService<ICustomerHttpService>, ICustomerService
    {
        public CustomerService(ICustomerHttpService service)
            : base(service)
        {
        }

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
    }
}