using Optivem.Core.Common.WebAutomation;
using Optivem.Test.Common.WebAutomation;
using System.Collections.Generic;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test.Pages
{
    public class ToolsQAAutomationPracticeFormPage
    {
        public ToolsQAAutomationPracticeFormPage(TestDriver driver)
        {
            Driver = driver;
        }

        public TestDriver Driver { get; private set; }

        public TestTextBox FirstName => Driver.FindTextBox(FindType.Name, "firstname");

        public TestTextBox LastName => Driver.FindTextBox(FindType.Name, "lastname");

        public TestRadioGroup Gender => Driver.FindRadioGroup(FindType.Name, "sex");

        public TestRadioGroup YearsOfExperience => Driver.FindRadioGroup(FindType.Name, "exp");

        public TestCheckBoxGroup Profession => Driver.FindCheckBoxGroup(FindType.Name, "profession");

        public TestCheckBoxGroup AutomationTool => Driver.FindCheckBoxGroup(FindType.Name, "tool");

        public TestComboBox Continent => Driver.FindComboBox(FindType.Name, "continents");

        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

}