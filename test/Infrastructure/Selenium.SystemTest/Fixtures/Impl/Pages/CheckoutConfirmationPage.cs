using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Pages;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Impl.Pages
{
    public class CheckoutConfirmationPage : Page, ICheckoutConfirmationPage
    {
        public CheckoutConfirmationPage(Driver finder, bool navigateTo = false)
            : base(finder, PageUrl, navigateTo)
        {
        }

        public static string PageUrl = "https://www.saucedemo.com/checkout-complete.html";


        private Element MessageHeaderElement => Finder.FindElement(FindBy.CssSelector(".complete-header"));

        private Element MessageTextElement => Finder.FindElement(FindBy.CssSelector(".complete-text"));


        public string GetMessageHeader()
        {
            return MessageHeaderElement.Text;
        }

        public string GetMessageText()
        {
            return MessageTextElement.Text;
        }
    }
}
