using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers
{
    public interface ICustomerApplicationService : IApplicationService
    {
        Task<BrowseCustomersQueryResponse> BrowseCustomersAsync(BrowseCustomersQuery request);

        Task<CreateCustomerCommandResponse> CreateCustomerAsync(CreateCustomerCommand request);

        Task<DeleteCustomerCommandResponse> DeleteCustomerAsync(DeleteCustomerCommand request);

        Task<FindCustomerQueryResponse> FindCustomerAsync(FindCustomerQuery request);

        Task<ListCustomersQueryResponse> ListCustomersAsync(ListCustomersQuery request);

        Task<UpdateCustomerCommandResponse> UpdateCustomerAsync(UpdateCustomerCommand request);
    }
}