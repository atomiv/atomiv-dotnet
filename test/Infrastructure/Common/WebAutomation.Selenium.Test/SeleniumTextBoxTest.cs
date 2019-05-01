using FluentAssertions;
using Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test.Pages;
using Xunit;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test
{
    public class SeleniumTextBoxTest : SeleniumFixtureTest
    {
        public SeleniumTextBoxTest(SeleniumDriverFixture seleniumFixture) : base(seleniumFixture)
        {
        }

        [Fact]
        public void TestSetGetText()
        {
            var driver = SeleniumFixture.Driver;

            driver.Url = "https://www.toolsqa.com/automation-practice-form/";

            var page = new ToolsQAAutomationPracticeFormPage(driver);

            // TODO: VC: Link text & partial link text

            page.FirstNameTextBox.SetText("John");
            var firstName = page.FirstNameTextBox.GetText();

            firstName.Should().Be("John");
        }
    }

    // TODO: VC: Create base classes for testing, so that interfaces are tested and this means same test could be for Selenium or other implementations
}
