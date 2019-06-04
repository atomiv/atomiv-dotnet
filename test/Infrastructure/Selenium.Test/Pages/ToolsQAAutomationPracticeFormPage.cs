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

        public TestRadioGroup<Gender?> Gender => Driver.FindRadioGroup(FindType.Name, "sex", new Dictionary<string, Gender?>
        {
            { "Male", Pages.Gender.Male },
            { "Female", Pages.Gender.Female },
        });

        public TestRadioGroup<int?> YearsOfExperience => Driver.FindRadioGroup(FindType.Name, "exp", new Dictionary<string, int?>
        {
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
        });

        public TestCheckBoxGroup<Profession?> Profession => Driver.FindCheckBoxGroup(FindType.Name, "profession", new Dictionary<string, Profession?>
        {
            { "Manual Tester", Pages.Profession.ManualTester },
            { "Automation Tester", Pages.Profession.AutomationTester },
        });

        public TestCheckBoxGroup<AutomationTool?> AutomationTool => Driver.FindCheckBoxGroup(FindType.Name, "tool", new Dictionary<string, AutomationTool?>
        {
            { "QTP", Pages.AutomationTool.Qtp },
            { "Selenium IDE", Pages.AutomationTool.SeleniumIde },
            { "Selenium Webdriver", Pages.AutomationTool.SeleniumWebDriver },
        });

        public TestComboBox<Continent?> Continent => Driver.FindComboBox(FindType.Name, "continents", new Dictionary<string, Continent?>
        {
            { "Asia", Pages.Continent.Asia },
            { "Europe", Pages.Continent.Europe },
            { "Africa", Pages.Continent.Africa },
            { "Australia", Pages.Continent.Australia },
            { "South America", Pages.Continent.SouthAmerica },
            { "North America", Pages.Continent.NorthAmerica },
            { "Antartica", Pages.Continent.Antartica },
        });

        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

    public enum Gender
    {
        Male, Female
    }

    public enum Profession
    {
        ManualTester,
        AutomationTester
    }

    public enum AutomationTool
    {
        Qtp,
        SeleniumIde,
        SeleniumWebDriver
    }

    // TODO: VC: Verify contents of groups, i.e. matching the expected elements

    public enum Continent
    {
        Asia,
        Europe,
        Africa,
        Australia,
        SouthAmerica,
        NorthAmerica,
        Antartica
    }
}