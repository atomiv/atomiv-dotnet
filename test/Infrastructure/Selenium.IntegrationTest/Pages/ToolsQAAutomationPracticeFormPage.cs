namespace Optivem.Atomiv.Infrastructure.Selenium.IntegrationTest.Pages
{
    public class ToolsQAAutomationPracticeFormPage : Page
    {
        public ToolsQAAutomationPracticeFormPage(Driver finder, bool navigateTo = false)
            : base(finder, "https://www.toolsqa.com/automation-practice-form/", navigateTo)
        {
        }

        public TextBox FirstName => Finder.FindTextBox(FindBy.Name("firstname"));

        public TextBox LastName => Finder.FindTextBox(FindBy.Name("lastname"));

        public RadioButtonGroup Gender => Finder.FindRadioButtonGroup(FindBy.Name("sex"));

        public RadioButtonGroup YearsOfExperience => Finder.FindRadioButtonGroup(FindBy.Name("exp"));

        public CheckBoxGroup Profession => Finder.FindCheckBoxGroup(FindBy.Name("profession"));

        public CheckBoxGroup AutomationTool => Finder.FindCheckBoxGroup(FindBy.Name("tool"));

        public ComboBox Continent => Finder.FindComboBox(FindBy.Name("continents"));

        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }
}