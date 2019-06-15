namespace Optivem.Core.Common.WebAutomation.Assertion
{
    public interface IAssertableMultiSelectElement : IAssertableElement
    {
        void ShouldHaveSelection();

        void ShouldNotHaveSelection();

        void ShouldHaveSelectedValue(string expected);

        void ShouldHaveSelectionCount(int expected);

        void ShouldHaveOneSelectedItem();

        void ShouldHaveOneSelectedValue(string expected);
    }
}
