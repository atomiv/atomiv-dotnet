using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class FindQuery : IFindQuery
    {
        public FindQuery(FindType findType, string findBy)
        {
            FindType = findType;
            FindBy = findBy;
        }

        public FindType FindType { get; }

        public string FindBy { get; }
    }
}
