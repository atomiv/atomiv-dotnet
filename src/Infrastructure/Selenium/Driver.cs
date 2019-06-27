using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class Driver : IDriver<Element, TextBox, CheckBox, ComboBox, Button, RadioButtonGroup, CheckBoxGroup> // TODO: VC: DELETE, IDriver
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
                { FindType.XPath, e => By.XPath(e) }
            };

        public Driver(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; private set; }

        public string Url
        {
            get { return WebDriver.Url; }
            set { WebDriver.Url = value; }
        }

        public CheckBox FindCheckBox(FindType findType, string findBy)
        {
            var element = FindWebElement(findType, findBy);

            if(element == null)
            {
                return null;
            }

            return new CheckBox(element);
        }

        public TextBox FindTextBox(FindType findType, string findBy)
        {
            var element = FindWebElement(findType, findBy);

            if (element == null)
            {
                return null;
            }

            return new TextBox(element);
        }

        public RadioButtonGroup FindRadioGroup(FindType findType, string findBy)
        {
            var elements = FindWebElements(findType, findBy);

            // TODO: VC: Check elements null

            return new RadioButtonGroup(elements);
        }


        public CheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy)
        {
            var elements = FindWebElements(findType, findBy);

            // TODO: VC: Check elements null

            return new CheckBoxGroup(elements);
        }



        public ComboBox FindComboBox(FindType findType, string findBy)
        {
            var element = FindWebElement(findType, findBy);

            if (element == null)
            {
                return null;
            }

            return new ComboBox(element);
        }



        public Button FindButton(FindType findType, string findBy)
        {
            var element = FindWebElement(findType, findBy);

            if (element == null)
            {
                return null;
            }

            return new Button(element);
        }

        public Element FindElement(FindType findType, string findBy)
        {
            var element = FindWebElement(findType, findBy);

            if (element == null)
            {
                return null;
            }

            return new Element(element);
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }


        #region Helper

        private ReadOnlyCollection<IWebElement> FindWebElements(FindType findType, string findBy)
        {
            var byGetter = findTypeMap[findType];
            var by = byGetter(findBy);
            return WebDriver.FindElements(by);
        }

        private IWebElement FindWebElement(FindType findType, string findBy)
        {
            var elements = FindWebElements(findType, findBy);
            return elements.SingleOrDefault();
        }

        #endregion Helper
    }
}