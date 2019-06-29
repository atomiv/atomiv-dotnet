using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Pages
{
    public class ToolsQAAutomationPracticeFormPage : Page
    {
        public ToolsQAAutomationPracticeFormPage(Driver driver, bool navigateTo = false) 
            : base(driver, "https://www.toolsqa.com/automation-practice-form/", navigateTo)
        {
        }

        public TextBox FirstName => Driver.FindTextBox(FindBy.Name("firstname"));

        public TextBox LastName => Driver.FindTextBox(FindBy.Name("lastname"));

        public RadioButtonGroup Gender => Driver.FindRadioButtonGroup(FindBy.Name("sex"));

        public RadioButtonGroup YearsOfExperience => Driver.FindRadioButtonGroup(FindBy.Name("exp"));

        public CheckBoxGroup Profession => Driver.FindCheckBoxGroup(FindBy.Name("profession"));

        public CheckBoxGroup AutomationTool => Driver.FindCheckBoxGroup(FindBy.Name("tool"));

        public ComboBox Continent => Driver.FindComboBox(FindBy.Name("continents"));

        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

}