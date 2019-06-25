using FluentAssertions;
using Optivem.Test.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium.IntegrationTest.Screens
{
    public class SauceDemoLoginScreen : TestScreen
    {
        private const string Url = "https://www.saucedemo.com/";

        public SauceDemoLoginScreen(TestDriver driver) : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        public TestTextBox UserName => Driver.FindTextBoxById("user-name");

        public TestTextBox Password => Driver.FindTextBoxById("password");

        public TestButton Login => Driver.FindButtonByClass("submit");

        public static SauceDemoLoginScreen Open(TestDriver driver)
        {
            driver.Url = Url;
            return new SauceDemoLoginScreen(driver);
        }
    }
}
