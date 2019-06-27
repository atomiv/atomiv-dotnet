using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App
{
    public class ToolsQAApp : PageObject
    {
        public ToolsQAApp(Driver driver)
            : base(driver)
        {
        }

        public ToolsQAAutomationPracticeFormPage OpenPracticeFormPage()
        {
            Driver.Url = "https://www.toolsqa.com/automation-practice-form/";
            return new ToolsQAAutomationPracticeFormPage(Driver);
        }
    }
}
