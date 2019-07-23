namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Pages
{
    public interface ICheckoutInformationPage
    {
        void InputFirstName(string firstName);

        void InputLastName(string lastName);

        void InputZipCode(string zipCode);

        void ClickCancel();

        void ClickContinue();

        string GetErrorMessage();
    }
}
