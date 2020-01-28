using Optivem.Atomiv.Infrastructure.Selenium.IntegrationTest.Pages;

namespace Optivem.Atomiv.Infrastructure.Selenium.IntegrationTest.App
{
    public class ToolsQAApp : App<ToolsQAAutomationPracticeFormPage>
    {
        public ToolsQAApp(Driver driver)
            : base(driver)
        {
        }

        public ToolsQAAutomationPracticeFormPage NavigateToPracticeFormPage()
        {
            return new ToolsQAAutomationPracticeFormPage(Finder, true);
        }
    }
}