using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens
{
    public class SauceDemoLoginPage : PageObject
    {
        private const string Url = "https://www.saucedemo.com/";

        public SauceDemoLoginPage(Driver driver) : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        public TextBox UserName => Driver.FindTextBox(FindType.Id, "user-name");

        public TextBox Password => Driver.FindTextBox(FindType.Id, "password");

        public Button Login => Driver.FindButton(FindType.ClassName, "submit");

        public static SauceDemoLoginPage Open(Driver driver)
        {
            driver.Url = Url;
            return new SauceDemoLoginPage(driver);
        }
    }
}
