using Optivem.Template.Web.RestClient.Interface;

namespace Optivem.Template.Web.RestClient
{
    public class ApiClient : IApiClient
    {
        public ApiClient(ICustomerControllerClient customers, IOrderControllerClient orders, IProductControllerClient products)
        {
            Customers = customers;
            Orders = orders;
            Products = products;
        }

        public ICustomerControllerClient Customers { get; }

        public IOrderControllerClient Orders { get; }

        public IProductControllerClient Products { get; }
    }
}