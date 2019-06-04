using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Selenium
{
    public static class SeleniumExtensions
    {
        public static string GetValueAttribute(this IWebElement webElement)
        {
            return webElement.GetAttribute("value");
        }
    }
}
