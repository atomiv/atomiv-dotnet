using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Common.WebAutomation;

namespace Optivem.Framework.Test.Selenium
{
    public class TestElement : TestElement<Element>
    {
        public TestElement(Element element) : base(element)
        {
        }
    }
}
