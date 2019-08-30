using Optivem.Cli.DependencyInjection;
using Optivem.Cli.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Test.AspNetCore;
using Optivem.Framework.Test.EntityFrameworkCore;
using Optivem.Cli.Web.RestClient.Http;
using Optivem.Cli.Web.RestClient.Interface;

namespace Optivem.Cli.Web.RestApi.IntegrationTest.Fixtures
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