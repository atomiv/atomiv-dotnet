using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium;
using SeleniumExtras.PageObjects;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium.Pages
{
    public class ToolsQAAutomationPracticeFormPage : SeleniumPage
    {
        [FindsBy(How = How.Name, Using = "firstname")]
        private IWebElement _firstNameElement;

        private ITextBox _firstNameTextBox;

        public ToolsQAAutomationPracticeFormPage(IWebDriver driver) 
            : base(driver)
        {
            _firstNameTextBox = new SeleniumTextBox(_firstNameElement);
        }

        public string GetFirstName()
        {
            return _firstNameTextBox.GetText();
        }

        public void SetFirstName(string value)
        {
            _firstNameTextBox.SetText(value);
        }
    }
}
