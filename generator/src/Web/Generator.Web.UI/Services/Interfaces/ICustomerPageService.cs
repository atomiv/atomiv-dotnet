using Atomiv.Web.AspNetCore.RazorPages;
using Generator.Web.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generator.Web.UI.Services.Interfaces
{
    public interface ICustomerPageService : IPageService
    {
        Task<IList<Customer>> ListCustomers();

        Task CreateCustomer(Customer customer);
    }
}
