using Optivem.Template.Core.Application.Customers.Commands;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IApiClient
    {
        ICustomerControllerClient Customers { get; }

        IOrderControllerClient Orders { get; }

        IProductControllerClient Products { get; }
    }
}