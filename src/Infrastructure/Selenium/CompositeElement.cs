using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class CompositeElement : PageObject<ElementRoot>, ICompositeElement
    {
        public CompositeElement(ElementRoot finder) : base(finder)
        {
        }
    }
}