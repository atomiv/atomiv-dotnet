using Optivem.Framework.Test.AspNetCore;
using Optivem.Framework.Test.EntityFrameworkCore;
using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.Persistence;
using Optivem.Template.Web.RestClient.Http;
using Optivem.Template.Web.RestClient.Interface;

namespace Optivem.Template.Web.RestApi.IntegrationTest.Fixtures
{
    public class ControllerFixture
    {
        public ControllerFixture()
        {
            Web = WebTestClientFactory.Create<Startup>();
            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e), ConfigurationKeys.SqlServerOptionsAction);

            Api = new ApiHttpService(Web.ControllerClientFactory);
        }

        public WebTestClient Web { get; }

        public DbTestClient<DatabaseContext> Db { get; }

        public IApiHttpService Api { get; }
    }
}