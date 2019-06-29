using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Fixtures;
using Optivem.Framework.Test.FluentAssertions.WebAutomation;
using Xunit;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest
{
    // TODO: Pending resolution of https://github.com/appveyor/ci/issues/2928

    public class ToolsQAPageTest : ToolsQATest
    {
        public ToolsQAPageTest(ToolsQAFixture fixture) : base(fixture)
        {
        }

        // [Fact(Skip = "Need fix test")]
        [Fact]
        public void TestFindTextBoxByName()
        {
            var page = Fixture.App.NavigateToPracticeFormPage();

            // TODO: VC: Link text & partial link text

            page.FirstName.EnterText("John");
            page.FirstName.TextShouldBe("John");

            /*
            // TODO: VC: Error: Message: OpenQA.Selenium.ElementClickInterceptedException : element click intercepted: Element <input id="sex-0" name="sex" type="radio" value="Male"> is not clickable at point (81, 891). Other element would receive the click: <div class="cookie-notice-container">...</div>
            (Session info: chrome = 75.0.3770.100)
  (Driver info: chromedriver = 74.0.3729.6(255758eccf3d244491b8a1317aa76e1ce10d57e9 - refs / branch - heads / 3729@{#29}),platform=Windows NT 10.0.17134 x86_64)
            */

            /*
            page.Gender.ShouldNotHaveSelection();
            page.Gender.SelectValue("Male");
            page.Gender.ShouldHaveSelectedValue("Male");
            */

            // TODO: VC: Error

            /*
             * 
             * 
Message: OpenQA.Selenium.ElementClickInterceptedException : element click intercepted: Element <input id="exp-2" name="exp" type="radio" value="3"> is not clickable at point (291, 891). Other element would receive the click: <div class="cookie-notice-container">...</div>
  (Session info: chrome=75.0.3770.100)
  (Driver info: chromedriver=74.0.3729.6 (255758eccf3d244491b8a1317aa76e1ce10d57e9-refs/branch-heads/3729@{#29}),platform=Windows NT 10.0.17134 x86_64)
             * 
             */


            /*
            page.YearsOfExperience.ShouldNotHaveSelection();
            page.YearsOfExperience.SelectValue("3");
            page.YearsOfExperience.ShouldHaveSelectedValue("3");
            */

            page.Profession.ShouldNotHaveSelection();
            page.Profession.EnsureValueSelected("Automation Tester");
            page.Profession.ShouldHaveOneSelectedValue("Automation Tester");

            // TODO: VC: Upload file

            // TODO: VC: Download file

            page.AutomationTool.ShouldNotHaveSelection();
            page.AutomationTool.EnsureValueSelected("Selenium IDE");
            page.AutomationTool.ShouldHaveOneSelectedValue("Selenium IDE");

            // TODO: VC: Testing multi select

            // TODO: VC: Checkboxes

            page.Continent.ShouldHaveSelectedValue("Asia");
            page.Continent.SelectByValue("Europe");
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