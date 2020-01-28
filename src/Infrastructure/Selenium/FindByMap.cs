using OpenQA.Selenium;
using Optivem.Atomiv.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Infrastructure.Selenium
{
    public static class FindByMap
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

        public static By GetBy(IQuery query)
        {
            var findType = query.FindType;
            var findBy = query.FindBy;

            var byGetter = findTypeMap[findType];
            var by = byGetter(findBy);

            return by;
        }
    }
}