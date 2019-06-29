using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public static class FindBy
    {
        public static FindQuery ClassName(string className)
        {
            return new FindQuery(FindType.ClassName, className);
        }

        public static FindQuery CssSelector(string cssSelector)
        {
            return new FindQuery(FindType.CssSelector, cssSelector);
        }

        public static FindQuery Id(string id)
        {
            return new FindQuery(FindType.Id, id);
        }

        public static FindQuery LinkText(string linkText)
        {
            return new FindQuery(FindType.LinkText, linkText);
        }

        public static FindQuery Name(string name)
        {
            return new FindQuery(FindType.Name, name);
        }

        public static FindQuery PartialLinkText(string partialLinkText)
        {
            return new FindQuery(FindType.PartialLinkText, partialLinkText);
        }

        public static FindQuery TagName(string tagName)
        {
            return new FindQuery(FindType.TagName, tagName);
        }

        public static FindQuery XPath(string xPath)
        {
            return new FindQuery(FindType.XPath, xPath);
        }
    }
}
