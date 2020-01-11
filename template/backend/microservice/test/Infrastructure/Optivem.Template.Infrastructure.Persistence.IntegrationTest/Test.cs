using Xunit;

namespace Optivem.Template.Infrastructure.Persistence.IntegrationTest
{
    public class Test : IClassFixture<Fixture>
    {
        public Test(Fixture fixture)
        {
            Fixture = fixture;
        }

        public Fixture Fixture { get; }
    }
}
