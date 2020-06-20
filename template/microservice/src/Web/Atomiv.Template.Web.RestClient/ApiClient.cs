using Atomiv.Template.Web.RestClient.Interface;

namespace Atomiv.Template.Web.RestClient
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