using Optivem.Core.Common.Http;
using Optivem.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Web.Test.Clients;
using Optivem.Test.AspNetCore.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Optivem.Template.Web.Test.Fixture
{
    // TODO: VC

    public class TestClient : BaseTestClient<Startup, DatabaseContext>
    {
        // TOD: VS: Check if connection key should be centralized? perhaps strongly typed configuration
        private const string DatabaseConnectionKey = "DefaultConnection";

        public TestClient()
            : base(DatabaseConnectionKey, e => new DatabaseContext(e))
        {
            Customers = new CustomersControllerClient(Client.ControllerClientFactory);
            Products = new ProductsControllerClient(Client.ControllerClientFactory);
        }

        public CustomersControllerClient Customers { get; }

        public ProductsControllerClient Products { get; }
    }
}