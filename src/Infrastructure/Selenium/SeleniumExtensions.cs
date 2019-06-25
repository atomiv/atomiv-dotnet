using OpenQA.Selenium;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public static class SeleniumExtensions
    {
        public static string GetValueAttribute(this IWebElement webElement)
        {
            return webElement.GetAttribute("value");
        }
    }
}
