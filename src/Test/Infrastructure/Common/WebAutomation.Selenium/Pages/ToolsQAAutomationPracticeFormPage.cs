using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium;
using SeleniumExtras.PageObjects;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium.Pages
{
    public class ToolsQAAutomationPracticeFormPage : SeleniumPage
    {
        public ToolsQAAutomationPracticeFormPage(IWebDriver driver) : base(driver)
        {
        }

        public ITextBox FirstNameTextBox => FindTextBox(By.Name("firstname"));

        public ITextBox LastNameTextBox => FindTextBox(By.Name("lastname"));

        public IRadioGroup<SexType?> SexRadioGroup => FindRadioGroup(By.Name("sex"), new Dictionary<string, SexType?>
            {
                { "Male", SexType.Male },
                { "Female", SexType.Female },
            });

        public IRadioGroup<int> YearsOfExperienceRadioGroup { get; private set; }
        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

    public enum SexType
    {
        Male, Female
    }
}
