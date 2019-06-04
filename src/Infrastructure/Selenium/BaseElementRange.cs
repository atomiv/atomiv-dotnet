using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Optivem.Infrastructure.Selenium
{
    public class BaseElementRange
    {
        public BaseElementRange(ReadOnlyCollection<IWebElement> elements)
        {
            Elements = elements;
        }

        public ReadOnlyCollection<IWebElement> Elements { get; private set; }
    }
}