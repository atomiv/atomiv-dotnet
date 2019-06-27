using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    // TODO: VC: Make this base class

    public class TestElement<TElement> : IAssertableElement
        where TElement : IElement
    {
        public TestElement(TElement element)
        {
            Element = element;
        }

        public TElement Element { get; }

        public bool Enabled => Element.Enabled;

        public bool Visible => Element.Visible;

        public void ShouldBeEnabled()
        {
            Enabled.Should().Be(true);
        }

        public void ShouldBeDisabled()
        {
            Enabled.Should().Be(false);
        }

        public void ShouldBeVisible()
        {
            Visible.Should().Be(true);
        }

        public void ShouldBeHidden()
        {
            Visible.Should().Be(false);
        }
    }

    // TODO: VC: DELETE

    /*
    public class TestElement : TestElement<IElement>
    {
        public TestElement(IElement element) : base(element)
        {
        }
    }
    */
}
