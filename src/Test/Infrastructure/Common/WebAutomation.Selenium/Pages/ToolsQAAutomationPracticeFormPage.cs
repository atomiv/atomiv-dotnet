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
        [FindsBy(How = How.Name, Using = "firstname")]
        private IWebElement _firstNameElement;

        [FindsBy(How = How.Name, Using = "lastname")]
        private IWebElement _lastNameElement;

        /*
        [FindsBy(How = How.Id, Using = "sex-0")]
        private IWebElement _sexMaleElement;

        [FindsBy(How = How.Id, Using = "sex-1")]
        private IWebElement _sexFemaleElement;
        */


        //[FindsBy(How = How.Name, Using = "sex")]
        //private ReadOnlyCollection<IWebElement> _sexElement;



        public ToolsQAAutomationPracticeFormPage(IWebDriver driver) 
            : base(driver)
        {

            var _sexElement = driver.FindElements(By.Name("sex"));

            SexRadioGroup = new SeleniumUniRadioGroup<SexType?>(_sexElement, new Dictionary<string, SexType?>
            {
                { "Male", SexType.Male },
                { "Female", SexType.Female },
            });


        }

        public ITextBox FirstNameTextBox => FindTextBox(By.Name("firstname"));

        public ITextBox LastNameTextBox => FindTextBox(By.Name("lastname"));

        public IRadioGroup<SexType?> SexRadioGroup { get; private set; }

        public IRadioGroup<int> YearsOfExperienceRadioGroup { get; private set; }
        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

    public enum SexType
    {
        Male, Female
    }
}
