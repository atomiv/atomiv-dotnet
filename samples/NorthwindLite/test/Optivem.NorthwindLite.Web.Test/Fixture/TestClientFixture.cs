using Optivem.NorthwindLite.Infrastructure.Persistence;
using Optivem.Test.Xunit.AspNetCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Web.Test.Fixture
{
    public class TestClientFixture : BaseTestClientFixture<TestClient, Startup, DatabaseContext>
    {
        public TestClientFixture(TestClient fixture) 
            : base(fixture)
        {
        }
    }
}
