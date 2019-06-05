using Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test.Pages;
using System.Linq;
using Xunit;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test
{
    // TODO: Pending resolution of https://github.com/appveyor/ci/issues/2928

    public class SeleniumPageTest : SeleniumFixtureTest
    {
        public SeleniumPageTest(SeleniumDriverFixture seleniumFixture) : base(seleniumFixture)
        {
        }

        // [Fact(Skip = "Need fix test")]
        [Fact]
        public void TestFindTextBoxByName()
        {
            var driver = SeleniumFixture.TestDriver;

            driver.Url = "https://www.toolsqa.com/automation-practice-form/";

            var page = new ToolsQAAutomationPracticeFormPage(driver);

            // TODO: VC: Link text & partial link text

            page.FirstName.EnterText("John");
            page.FirstName.TextShouldBe("John");

            page.Gender.ShouldNotHaveSelection();
            page.Gender.SelectValue("Male");
            page.Gender.ShouldHaveSelectedValue("Male");

            page.YearsOfExperience.ShouldNotHaveSelection();
            page.YearsOfExperience.SelectValue("3");
            page.YearsOfExperience.ShouldHaveSelectedValue("3");

            page.Profession.ShouldNotHaveSelection();
            page.Profession.SelectValue("Automation Tester");
            page.Profession.ShouldHaveOneSelectedValue("Automation Tester");

            // TODO: VC: Upload file

            // TODO: VC: Download file

            page.AutomationTool.ShouldNotHaveSelection();
            page.AutomationTool.SelectValue("Selenium IDE");
            page.AutomationTool.ShouldHaveOneSelectedValue("Selenium IDE");

            // TODO: VC: Testing multi select

            // TODO: VC: Checkboxes

            page.Continent.ShouldHaveSelectedValue("Asia");
            page.Continent.SelectValue("Europe");
            page.Continent.ShouldHaveSelectedValue("Europe");

            // TODO: VC: fluent assertions, e.g. pageProfessionCheckBox.SelectedValueShouldBe(), ShouldNotHaveSelection, ShouldHaveSingleSelection, ShouldHaveSelectedItems(items)
            // TODO: VC: textBox - InputText(""), ShouldBeEmpty, ShouldHaveValue, ValueShouldBe(), ShouldBeNonEmpty

            // TODO: VC: Assert messages
        }


        /*
         * 
         * 
, new Dictionary<string, AutomationTool?>
        {
            { "QTP", Pages.AutomationTool.Qtp },
            { "Selenium IDE", Pages.AutomationTool.SeleniumIde },
            { "Selenium Webdriver", Pages.AutomationTool.SeleniumWebDriver },
        })
         * 
         */

        /*
         * 
        {
            { "Asia", Pages.Continent.Asia },
            { "Europe", Pages.Continent.Europe },
            { "Africa", Pages.Continent.Africa },
            { "Australia", Pages.Continent.Australia },
            { "South America", Pages.Continent.SouthAmerica },
            { "North America", Pages.Continent.NorthAmerica },
            { "Antartica", Pages.Continent.Antartica },
        }
         * 
         */

        /*
         * 
         * 

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
         * 
         * 
         */
    }
}