using Xunit;

namespace Optivem.Platform.Test.Common.Xunit.AspNetCore
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
