using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Infrastructure.Selenium
{
    public static class FindBy
    {
        public static Query ClassName(string className)
        {
            return new Query(FindType.ClassName, className);
        }

        public static Query CssSelector(string cssSelector)
        {
            return new Query(FindType.CssSelector, cssSelector);
        }

        public static Query Id(string id)
        {
            return new Query(FindType.Id, id);
        }

        public static Query LinkText(string linkText)
        {
            return new Query(FindType.LinkText, linkText);
        }

        public static Query Name(string name)
        {
            return new Query(FindType.Name, name);
        }

        public static Query PartialLinkText(string partialLinkText)
        {
            return new Query(FindType.PartialLinkText, partialLinkText);
        }

        public static Query TagName(string tagName)
        {
            return new Query(FindType.TagName, tagName);
        }

        public static Query XPath(string xPath)
        {
            return new Query(FindType.XPath, xPath);
        }
    }
}