using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class Query : IQuery
    {
        public Query(FindType findType, string findBy)
        {
            FindType = findType;
            FindBy = findBy;
        }

        public FindType FindType { get; }

        public string FindBy { get; }
    }
}
