using Xunit;

namespace Optivem.Framework.Test.Xunit
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
