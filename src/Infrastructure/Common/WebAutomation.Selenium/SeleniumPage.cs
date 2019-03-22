using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public abstract class SeleniumPage : IPage
    {
        private static Dictionary<FindType, Func<string, By>> findTypeMap 
            = new Dictionary<FindType, Func<string, By>>
            {
                { FindType.ClassName, e => By.ClassName(e) },
                { FindType.CssSelector, e => By.CssSelector(e) },
                { FindType.Id, e => By.Id(e) },
                { FindType.LinkText, e => By.LinkText(e) },
                { FindType.Name, e => By.Name(e) },
                { FindType.PartialLinkText, e => By.PartialLinkText(e) },
                { FindType.TagName, e => By.TagName(e) },
                { FindType.XPath, e => By.XPath(e) },
            };

        private IWebDriver _driver;

        public SeleniumPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ICheckBox GetCheckBox(FindType findType, string findBy)
        {
            var element = GetElement(findType, findBy);
            return new SeleniumCheckBox(element);
        }

        public ITextBox GetTextBox(FindType findType, string findBy)
        {
            var element = GetElement(findType, findBy);
            return new SeleniumTextBox(element);
        }

        private IWebElement GetElement(FindType findType, string findBy)
        {
            var byGetter = findTypeMap[findType];
            var by = byGetter(findBy);
            return _driver.FindElement(by);
        }
    }
}
