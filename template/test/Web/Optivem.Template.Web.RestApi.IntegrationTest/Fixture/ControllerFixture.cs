using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Web.IntegrationTest.Clients;
using Optivem.Framework.Test.AspNetCore;
using Optivem.Framework.Test.EntityFrameworkCore;
using Optivem.Template.Web.RestApi;

namespace Optivem.Template.Web.Test.Fixture
{
    public class ControllerFixture
    {
        public ControllerFixture()
        {
            Web = WebTestClientFactory.Create<Startup>();
            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e));

            Customers = new CustomersControllerClient(Web.ControllerClientFactory);
            Products = new ProductsControllerClient(Web.ControllerClientFactory);
        }

        public WebTestClient Web { get; }

        public DbTestClient<DatabaseContext> Db { get; }

        public CustomersControllerClient Customers { get; }

        public ProductsControllerClient Products { get; }
    }
}