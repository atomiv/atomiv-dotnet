using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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



        public SeleniumPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver Driver { get; private set; }

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
            return Driver.FindElement(by);
        }

        protected IWebElement FindSingle(By by)
        {
            return Driver.FindElements(by).Single();
        }

        protected IWebElement FindSingleOrDefault(By by)
        {
            return Driver.FindElements(by).SingleOrDefault();
        }

        protected IWebElement FindFirst(By by)
        {
            return Driver.FindElements(by).First();
        }

        protected IWebElement FindFirstOrDefault(By by)
        {
            return Driver.FindElements(by).FirstOrDefault();
        }

        protected ReadOnlyCollection<IWebElement> FindAll(By by)
        {
            return Driver.FindElements(by);
        }

        protected SeleniumTextBox FindTextBox(By by)
        {
            var element = FindSingle(by);
            return new SeleniumTextBox(element);
        }

        protected SeleniumRadioGroup<T> FindRadioGroup<T>(By by, Dictionary<string, T> map)
        {
            var elements = FindAll(by);
            return new SeleniumRadioGroup<T>(elements, map);

            // TODO: VC: Maped radio group without mapping, e.g. when want to access raw strings, or perhaps ints, where there is no fixed range in advance
        }

        protected SeleniumCheckBoxGroup<T> FindCheckBoxGroup<T>(By by, Dictionary<string, T> map)
        {
            var elements = FindAll(by);
            return new SeleniumCheckBoxGroup<T>(elements, map);

            // TODO: VC: Maped radio group without mapping, e.g. when want to access raw strings, or perhaps ints, where there is no fixed range in advance
        }

        protected SeleniumComboBox<T> FindComboBox<T>(By by, Dictionary<string, T> map)
        {
            var elements = FindAll(by);
            return new SeleniumComboBox<T>(elements, map);

            // TODO: VC: Maped radio group without mapping, e.g. when want to access raw strings, or perhaps ints, where there is no fixed range in advance
        }
    }
}
