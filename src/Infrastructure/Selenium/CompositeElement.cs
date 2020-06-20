using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Infrastructure.Selenium
{
    public class CompositeElement : PageObject<ElementRoot>, ICompositeElement
    {
        public CompositeElement(ElementRoot finder) : base(finder)
        {
        }
    }
}