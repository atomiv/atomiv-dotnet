using Optivem.Generator.DependencyInjection;
using Optivem.Generator.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Test.AspNetCore;
using Optivem.Atomiv.Test.EntityFrameworkCore;
using Optivem.Generator.Web.RestClient.Http;
using Optivem.Generator.Web.RestClient.Interface;

namespace Optivem.Generator.Web.RestApi.IntegrationTest.Fixtures
{
    public class ControllerFixture
    {
        public ControllerFixture()
        {
            Web = WebTestClientFactory.Create<Startup>();
            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e));

            Api = new ApiHttpService(Web.ControllerClientFactory);
        }

        public WebTestClient Web { get; }

        public DbTestClient<DatabaseContext> Db { get; }

        public IApiHttpService Api { get; }
    }
}