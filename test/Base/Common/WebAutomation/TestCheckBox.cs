using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestCheckBox<TCheckBox> : TestElement<TCheckBox>, IAssertableCheckBox
        where TCheckBox : ICheckBox
    {
        public TestCheckBox(TCheckBox element)
            : base(element)
        {
        }
    }
    
    // TODO: VC: DELETE

    /*
    public class TestCheckBox : TestCheckBox<ICheckBox>
    {
        public TestCheckBox(ICheckBox element) : base(element)
        {
        }
    }
    */
}
