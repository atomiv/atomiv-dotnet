using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestCheckBox<TCheckBox> : TestElement<TCheckBox>, ICheckBox
        where TCheckBox : ICheckBox
    {
        public TestCheckBox(TCheckBox element)
            : base(element)
        {
        }
    }

    public class TestCheckBox : TestCheckBox<ICheckBox>
    {
        public TestCheckBox(ICheckBox element) : base(element)
        {
        }
    }
}
