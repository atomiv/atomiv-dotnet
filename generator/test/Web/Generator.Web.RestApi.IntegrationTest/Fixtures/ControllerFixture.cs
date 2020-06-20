using Generator.DependencyInjection;
using Generator.Infrastructure.EntityFrameworkCore;
using Atomiv.Test.AspNetCore;
using Atomiv.Test.EntityFrameworkCore;
using Generator.Web.RestClient.Http;
using Generator.Web.RestClient.Interface;

namespace Generator.Web.RestApi.IntegrationTest.Fixtures
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