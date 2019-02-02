using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Optivem.Platform.Test.Web.AspNetCore.Common
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
