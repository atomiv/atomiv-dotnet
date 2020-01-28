using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient.Interface
{
    public interface IApiClient
    {
        ICustomerControllerClient Customers { get; }

        IOrderControllerClient Orders { get; }

        IProductControllerClient Products { get; }
    }
}