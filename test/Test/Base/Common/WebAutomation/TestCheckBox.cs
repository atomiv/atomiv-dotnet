using Optivem.Core.Common.WebAutomation;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestCheckBox : ICheckBox
    {
        private readonly ICheckBox _checkBox;

        public TestCheckBox(ICheckBox checkBox)
        {
            _checkBox = checkBox;
        }

        public bool Enabled => _checkBox.Enabled;

        public bool Visible => _checkBox.Visible;
    }
}
