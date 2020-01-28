using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Infrastructure.Selenium
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