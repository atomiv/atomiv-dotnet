using Cli.DependencyInjection;
using Cli.Infrastructure.EntityFrameworkCore;
using Atomiv.Test.AspNetCore;
using Atomiv.Test.EntityFrameworkCore;
using Cli.Web.RestClient.Http;
using Cli.Web.RestClient.Interface;

namespace Cli.Web.RestApi.IntegrationTest.Fixtures
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