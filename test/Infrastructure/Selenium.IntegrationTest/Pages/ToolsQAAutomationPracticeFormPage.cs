using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Pages
{
    public class ToolsQAAutomationPracticeFormPage : PageObject
    {
        public ToolsQAAutomationPracticeFormPage(Driver driver) 
            : base(driver)
        {
        }

        public TextBox FirstName => Driver.FindTextBox(FindType.Name, "firstname");

        public TextBox LastName => Driver.FindTextBox(FindType.Name, "lastname");

        public RadioButtonGroup Gender => Driver.FindRadioGroup(FindType.Name, "sex");

        public RadioButtonGroup YearsOfExperience => Driver.FindRadioGroup(FindType.Name, "exp");

        public CheckBoxGroup Profession => Driver.FindCheckBoxGroup(FindType.Name, "profession");

        public CheckBoxGroup AutomationTool => Driver.FindCheckBoxGroup(FindType.Name, "tool");

        public ComboBox Continent => Driver.FindComboBox(FindType.Name, "continents");

        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

}