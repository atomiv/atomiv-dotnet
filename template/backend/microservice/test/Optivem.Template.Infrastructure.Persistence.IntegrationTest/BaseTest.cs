using Xunit;

namespace Optivem.Template.Infrastructure.Persistence.IntegrationTest
{
    public class BaseTest : IClassFixture<Fixture>
    {
        public BaseTest(Fixture fixture)
        {
            Fixture = fixture;
        }

        public Fixture Fixture { get; }
    }
}
