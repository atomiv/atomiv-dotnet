using Optivem.Core.Common;
using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Test.EntityFrameworkCore;

namespace Optivem.Template.Core.Application.IntegrationTest.Fixture
{
    public class ServiceFixture
    {
        public ServiceFixture()
        {
            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e));
        }

        public DbTestClient<DatabaseContext> Db { get; }
    }
}
