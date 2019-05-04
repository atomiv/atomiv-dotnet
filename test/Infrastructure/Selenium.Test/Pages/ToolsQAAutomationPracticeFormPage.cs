using System.Collections.Generic;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test.Pages
{
    public class ToolsQAAutomationPracticeFormPage
    {
        public ToolsQAAutomationPracticeFormPage(IDriver driver)
        {
            Driver = driver;
        }

        public IDriver Driver { get; private set; }

        public ITextBox FirstNameTextBox => Driver.FindTextBox(FindType.Name, "firstname");

        public ITextBox LastNameTextBox => Driver.FindTextBox(FindType.Name, "lastname");

        public IRadioGroup<Sex?> SexRadioGroup => Driver.FindRadioGroup(FindType.Name, "sex", new Dictionary<string, Sex?>
        {
            { "Male", Sex.Male },
            { "Female", Sex.Female },
        });

        public IRadioGroup<int?> YearsOfExperienceRadioGroup => Driver.FindRadioGroup(FindType.Name, "exp", new Dictionary<string, int?>
        {
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
        });

        public ICheckBoxGroup<Profession?> ProfessionCheckBoxGroup => Driver.FindCheckBoxGroup(FindType.Name, "profession", new Dictionary<string, Profession?>
        {
            { "Manual Tester", Profession.ManualTester },
            { "Automation Tester", Profession.AutomationTester },
        });

        public ICheckBoxGroup<AutomationTool?> AutomationToolCheckBoxGroup => Driver.FindCheckBoxGroup(FindType.Name, "tool", new Dictionary<string, AutomationTool?>
        {
            { "QTP", AutomationTool.Qtp },
            { "Selenium IDE", AutomationTool.SeleniumIde },
            { "Selenium Webdriver", AutomationTool.SeleniumWebDriver },
        });

        public IComboBox<Continent?> ContinentComboBox => Driver.FindComboBox(FindType.Name, "continents", new Dictionary<string, Continent?>
        {
            { "Asia", Continent.Asia },
            { "Europe", Continent.Europe },
            { "Africa", Continent.Africa },
            { "Australia", Continent.Australia },
            { "South America", Continent.SouthAmerica },
            { "North America", Continent.NorthAmerica },
            { "Antartica", Continent.Antartica },
        });


        // TODO: VC: Radio group with names: https://www.toolsqa.com/selenium-webdriver/checkbox-radio-button-operations/
    }

    public enum Sex
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
