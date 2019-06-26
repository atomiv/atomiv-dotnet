using FluentAssertions;
using Optivem.Framework.Test.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens
{
    public class SauceDemoLoginPage : TestPageObject
    {
        private const string Url = "https://www.saucedemo.com/";

        public SauceDemoLoginPage(TestDriver driver) : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        public TestTextBox UserName => Driver.FindTextBoxById("user-name");

        public TestTextBox Password => Driver.FindTextBoxById("password");

        public TestButton Login => Driver.FindButtonByClass("submit");

        public static SauceDemoLoginPage Open(TestDriver driver)
        {
            driver.Url = Url;
            return new SauceDemoLoginPage(driver);
        }
    }
}
