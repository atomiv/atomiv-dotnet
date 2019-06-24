using Optivem.Core.Common.WebAutomation;
using Optivem.Core.Common.WebAutomation.Assertion;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestButton<TButton> : TestElement<TButton>, IAssertableButton
        where TButton : IButton
    {
        public TestButton(TButton element)
            : base(element)
        {
        }

        public void Click()
        {
            Element.Click();
        }
    }

    public class TestButton : TestButton<IButton>
    {
        public TestButton(IButton element) : base(element)
        {
        }
    }
}
