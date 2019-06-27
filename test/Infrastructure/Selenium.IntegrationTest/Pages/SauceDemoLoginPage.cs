using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens
{
    public class SauceDemoLoginPage : Page
    {
        public SauceDemoLoginPage(Driver driver, bool navigateTo) 
            : base(driver, "https://www.saucedemo.com/", navigateTo)
        {
            Driver.Url.Should().Be(Url);
        }

        public TextBox UserName => Driver.FindTextBox(FindType.Id, "user-name");

        public TextBox Password => Driver.FindTextBox(FindType.Id, "password");

        public Button Login => Driver.FindButton(FindType.ClassName, "submit");
    }
}
