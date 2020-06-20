using Atomiv.Core.Common.Http;
using Atomiv.Infrastructure.AspNetCore;
using Generator.Web.RestClient.Interface;

namespace Generator.Web.RestClient.Http
{
    public class ApiHttpService : BaseApiClient, IApiHttpService
    {
        public ApiHttpService(IControllerClientFactory clientFactory)
            : base(clientFactory)
        {
            Customers = new CustomerHttpService(clientFactory);
            Products = new ProductHttpService(clientFactory);
        }

        public ICustomerHttpService Customers { get; }

        public IProductHttpService Products { get; }
    }
}
