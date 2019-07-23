using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Test.AspNetCore;
using Optivem.Framework.Test.EntityFrameworkCore;
using Optivem.Template.Web.RestApi.IntegrationTest.Fixtures.Clients;
using Optivem.Template.Web.RestClient.Http.Interface;
using Optivem.Template.Web.RestClient.Http;

namespace Optivem.Template.Web.RestApi.IntegrationTest.Fixtures
{
    public class ControllerFixture
    {
        public ControllerFixture()
        {
            Web = WebTestClientFactory.Create<Startup>();
            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e));

            // Customers = new CustomersControllerClient(Web.ControllerClientFactory);
            Customers = new HttpCustomerService(Web.ControllerClientFactory);
            Products = new ProductsControllerClient(Web.ControllerClientFactory);
        }

        public WebTestClient Web { get; }

        public DbTestClient<DatabaseContext> Db { get; }

        // public CustomersControllerClient Customers { get; }

        public IHttpCustomerService Customers { get; }

        public ProductsControllerClient Products { get; }
    }
}