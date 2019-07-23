namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Pages
{
    public interface ICheckoutOverviewPage
    {
        void ClickCancel();

        void ClickFinish();

        string GetCardNumber();

        string GetShippingInformation();

        decimal GetSubTotal();
    }
}
