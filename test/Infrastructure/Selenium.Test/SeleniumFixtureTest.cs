using Xunit;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test
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