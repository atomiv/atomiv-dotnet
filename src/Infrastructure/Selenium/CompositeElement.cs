using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Infrastructure.Selenium
{
    public class CompositeElement : PageObject<ElementRoot>, ICompositeElement
    {
        public CompositeElement(ElementRoot finder) : base(finder)
        {
        }
    }
}