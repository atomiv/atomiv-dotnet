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


            // TODO: VC: Check if this should be via textbox?

            Assert.False(page.SexRadioGroup.HasSelected());

            page.SexRadioGroup.Select(Sex.Male);

            // TODO: VC: Automatic matching between name and enum

            Assert.Equal(Sex.Male, page.SexRadioGroup.ReadSelected());

            Assert.False(page.YearsOfExperienceRadioGroup.HasSelected());

            page.YearsOfExperienceRadioGroup.Select(3);

            Assert.Equal(3, page.YearsOfExperienceRadioGroup.ReadSelected());

            Assert.False(page.ProfessionCheckBoxGroup.HasSelected());

            page.ProfessionCheckBoxGroup.Select(Profession.AutomationTester);

            Assert.Single(page.ProfessionCheckBoxGroup.ReadSelected());

            Assert.Equal(Profession.AutomationTester, page.ProfessionCheckBoxGroup.ReadSelected().Single());

            // TODO: VC: Upload file

            // TODO: VC: Download file

            Assert.False(page.AutomationToolCheckBoxGroup.HasSelected());

            page.AutomationToolCheckBoxGroup.Select(AutomationTool.SeleniumIde);

            Assert.Single(page.AutomationToolCheckBoxGroup.ReadSelected());

            Assert.Equal(AutomationTool.SeleniumIde, page.AutomationToolCheckBoxGroup.ReadSelected().Single());

            // TODO: VC: Testing multi select

            // TODO: VC: Checkboxes

            Assert.True(page.ContinentComboBox.HasSelected());
            Assert.Equal(Continent.Asia, page.ContinentComboBox.ReadSelected());
            page.ContinentComboBox.Select(Continent.Europe);
            Assert.Equal(Continent.Europe, page.ContinentComboBox.ReadSelected());

            // TODO: VC: fluent assertions, e.g. pageProfessionCheckBox.SelectedValueShouldBe(), ShouldNotHaveSelection, ShouldHaveSingleSelection, ShouldHaveSelectedItems(items)
            // TODO: VC: textBox - InputText(""), ShouldBeEmpty, ShouldHaveValue, ValueShouldBe(), ShouldBeNonEmpty

            // TODO: VC: Assert messages
        }
    }
}