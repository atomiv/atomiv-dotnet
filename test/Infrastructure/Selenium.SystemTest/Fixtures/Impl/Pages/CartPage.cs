using Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Pages;

namespace Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Impl.Pages
{
    public class CartPage : Page, ICartPage
    {
        public CartPage(Driver finder, bool navigateTo = false)
            : base(finder, PageUrl, navigateTo)
        {
        }

        public static string PageUrl = "https://www.saucedemo.com/cart.html";

        private Button CheckoutButton => Finder.FindButton(FindBy.CssSelector(".checkout_button"));

        private Button ContinueButton => Finder.FindButton(FindBy.CssSelector(".btn_secondary"));

        public void ClickCheckout()
        {
            CheckoutButton.Click();
        }

        public void ClickContinueShopping()
        {
            ContinueButton.Click();
        }
    }
}