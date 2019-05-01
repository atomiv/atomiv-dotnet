using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumDriver : IDriver
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

        public SeleniumDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; private set; }

        public string Url
        {
            get { return Driver.Url; }
            set { Driver.Url = value; }
        }

        public ICheckBox FindCheckBox(FindType findType, string findBy)
        {
            var element = FindElement(findType, findBy);
            return new SeleniumCheckBox(element);
        }

        public ITextBox FindTextBox(FindType findType, string findBy)
        {
            var element = FindElement(findType, findBy);
            return new SeleniumTextBox(element);
        }

        public IRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var elements = FindElements(findType, findBy);
            return new SeleniumRadioGroup<T>(elements, values);
        }

        public ICheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var elements = FindElements(findType, findBy);
            return new SeleniumCheckBoxGroup<T>(elements, values);
        }

        public IComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var element = FindElement(findType, findBy);
            return new SeleniumComboBox<T>(element, values);
        }

        #region Helper

        private ReadOnlyCollection<IWebElement> FindElements(FindType findType, string findBy)
        {
            var byGetter = findTypeMap[findType];
            var by = byGetter(findBy);
            return Driver.FindElements(by);
        }

        private IWebElement FindElement(FindType findType, string findBy)
        {
            var elements = FindElements(findType, findBy);
            return elements.Single();
        }

        #endregion
    }
}
