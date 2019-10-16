using OpenQA.Selenium;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public static class SeleniumExtensions
    {
        public static string GetAttribute(this IWebElement webElement, string attributeName)
        {
            return webElement.GetAttribute(attributeName);
        }

        public static string GetValueAttribute(this IWebElement webElement)
        {
            return webElement.GetAttribute("value");
        }
    }
}