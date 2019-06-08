using FluentAssertions;
using Optivem.Core.Common.WebAutomation;
using Optivem.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Selenium.Test.Screens
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
