using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;

namespace Optivem.Framework.Test.Common.WebAutomation
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

    // TODO: VC: DELETE

    /*
    public class TestButton : TestButton<IButton>
    {
        public TestButton(IButton element) : base(element)
        {
        }
    }
    */
}
