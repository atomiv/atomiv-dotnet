using Optivem.Core.Application;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Core.Application.Interface.Services
{
    public interface ICustomerService : IService
    {
        Task<ListCustomersResponse> ListCustomersAsync();
    }
}
