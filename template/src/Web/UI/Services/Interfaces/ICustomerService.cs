using Optivem.Template.Web.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<Customer>> ListCustomers();
    }
}
