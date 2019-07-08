using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces
{
    public interface IApp
    {
        ILoginPage OpenLoginPage();

        IProductPage OpenProductPage();

        bool IsLoginPageOpen();

        bool IsProductPageOpen();

        IProductPage GetProductPage();

        ICartPage GetCartPage();

        ICheckoutInformationPage GetCheckoutInformationPage();

        ICheckoutOverviewPage GetCheckoutOverviewPage();

        ICheckoutConfirmationPage GetCheckoutConfirmationPage();
    }
}
