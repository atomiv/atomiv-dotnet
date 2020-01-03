using System;
using System.Collections.Generic;
using System.Text;
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
