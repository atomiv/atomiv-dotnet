using OpenQA.Selenium.Chrome;
using Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumFinderTest
    {
        [Fact]
        public void TestFindTextBoxByName()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (var driver = new ChromeDriver(currentDir))
            {
                driver.Url = "https://www.toolsqa.com/automation-practice-form/";

                var finder = new SeleniumFinder(driver);

                var textbox = finder.FindTextBoxByName("firstname");

                textbox.SetText("This is my name");
                var text = textbox.GetText();
            }
        }
    }
}
