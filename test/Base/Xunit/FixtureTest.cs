using Xunit;

namespace Optivem.Test.Xunit
{
    public class FixtureTest<TFixture> : IClassFixture<TFixture>
        where TFixture : class
    {
        public FixtureTest(TFixture fixture)
        {
            Fixture = fixture;
        }

        public TFixture Fixture { get; private set; }
    }
}
