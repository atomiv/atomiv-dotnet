using Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Pages;
using Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces
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