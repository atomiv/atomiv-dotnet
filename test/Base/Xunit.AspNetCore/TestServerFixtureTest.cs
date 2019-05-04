using Xunit;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class TestServerFixtureTest<TTestServerFixture> : IClassFixture<TTestServerFixture>
        where TTestServerFixture : TestServerFixture
    {
        public TestServerFixtureTest(TTestServerFixture testServerFixture)
        {
            TestServerFixture = testServerFixture;
        }

        protected TTestServerFixture TestServerFixture { get; private set; }

    }
}
