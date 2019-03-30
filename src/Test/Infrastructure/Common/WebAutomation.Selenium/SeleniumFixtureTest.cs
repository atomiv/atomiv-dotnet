using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumFixtureTest : IClassFixture<SeleniumFixture>
    {
        public SeleniumFixtureTest(SeleniumFixture seleniumFixture)
        {
            SeleniumFixture = seleniumFixture;
        }

        public SeleniumFixture SeleniumFixture { get; private set; }

    }
}
