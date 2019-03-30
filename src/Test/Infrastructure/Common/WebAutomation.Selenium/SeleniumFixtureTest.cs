using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumFixtureTest : IClassFixture<SeleniumDriverFixture>
    {
        public SeleniumFixtureTest(SeleniumDriverFixture seleniumFixture)
        {
            SeleniumFixture = seleniumFixture;
        }

        public SeleniumDriverFixture SeleniumFixture { get; private set; }

    }
}
