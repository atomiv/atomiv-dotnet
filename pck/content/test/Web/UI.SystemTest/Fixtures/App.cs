using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Impl.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class App : App<LoginPage>, IApp
    {
        public App(Driver finder)
            : base(finder)
        {
        }

        public IProductPage GetProductPage()
        {
            return new ProductPage(Finder);
        }

        public ICartPage GetCartPage()
        {
            return new CartPage(Finder);
        }

        public ICheckoutInformationPage GetCheckoutInformationPage()
        {
            return new CheckoutInformationPage(Finder);
        }

        public ICheckoutConfirmationPage GetCheckoutConfirmationPage()
        {
            return new CheckoutConfirmationPage(Finder);
        }

        public ICheckoutOverviewPage GetCheckoutOverviewPage()
        {
            return new CheckoutOverviewPage(Finder);
        }

        public bool IsLoginPageOpen()
        {
            return LoginPage.IsOpen(Finder);
        }

        public bool IsProductPageOpen()
        {
            return ProductPage.IsOpen(Finder);
        }

        public ILoginPage OpenLoginPage()
        {
            return new LoginPage(Finder, true);
        }

        public IProductPage OpenProductPage()
        {
            return new ProductPage(Finder, true);
        }

    }
}
