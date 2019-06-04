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
            page.Gender.Select(Gender.Male);
            page.Gender.ShouldHaveSelection(Gender.Male);

            page.YearsOfExperience.ShouldNotHaveSelection();
            page.YearsOfExperience.Select(3);
            page.YearsOfExperience.ShouldHaveSelection(3);

            page.Profession.ShouldNotHaveSelection();
            page.Profession.Select(Profession.AutomationTester);
            page.Profession.ShouldHaveOneSelectedItem();

            Assert.Single(page.Profession.ReadSelected());

            Assert.Equal(Profession.AutomationTester, page.Profession.ReadSelected().Single());

            // TODO: VC: Upload file

            // TODO: VC: Download file

            Assert.False(page.AutomationTool.HasSelected());

            page.AutomationTool.Select(AutomationTool.SeleniumIde);

            Assert.Single(page.AutomationTool.ReadSelected());

            Assert.Equal(AutomationTool.SeleniumIde, page.AutomationTool.ReadSelected().Single());

            // TODO: VC: Testing multi select

            // TODO: VC: Checkboxes

            Assert.True(page.Continent.HasSelected());
            Assert.Equal(Continent.Asia, page.Continent.ReadSelected());
            page.Continent.Select(Continent.Europe);
            Assert.Equal(Continent.Europe, page.Continent.ReadSelected());

            // TODO: VC: fluent assertions, e.g. pageProfessionCheckBox.SelectedValueShouldBe(), ShouldNotHaveSelection, ShouldHaveSingleSelection, ShouldHaveSelectedItems(items)
            // TODO: VC: textBox - InputText(""), ShouldBeEmpty, ShouldHaveValue, ValueShouldBe(), ShouldBeNonEmpty

            // TODO: VC: Assert messages
        }
    }
}