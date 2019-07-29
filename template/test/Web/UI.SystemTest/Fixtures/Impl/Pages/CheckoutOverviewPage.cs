using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Pages;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Impl.Pages
{
    public class CheckoutOverviewPage : Page, ICheckoutOverviewPage
    {
        public CheckoutOverviewPage(Driver finder, bool navigateTo = false)
            : base(finder, PageUrl, navigateTo)
        {
        }

        public static string PageUrl = "https://www.saucedemo.com/checkout-step-two.html";


        private Button CancelButton => Finder.FindButton(FindBy.CssSelector(".cart_cancel_link"));

        private Button FinishButton => Finder.FindButton(FindBy.CssSelector(".cart_button"));

        private Element CardNumberElement => Finder.FindElements(FindBy.CssSelector(".summary_value_label")).ElementAt(0);

        private Element ShippingInformationElement => Finder.FindElements(FindBy.CssSelector(".summary_value_label")).ElementAt(1);

        private Element SubtotalElement => Finder.FindElement(FindBy.CssSelector(".summary_subtotal_label"));

        public void ClickCancel()
        {
            CancelButton.Click();
        }

        public void ClickFinish()
        {
            FinishButton.Click();
        }

        public string GetCardNumber()
        {
            return CardNumberElement.Text;
        }

        public string GetShippingInformation()
        {
            return ShippingInformationElement.Text;
        }

        public decimal GetSubTotal()
        {
            var subtotal = SubtotalElement.Text;
            subtotal = subtotal.Replace("Item total: $", "");
            return decimal.Parse(subtotal);
        }
    }
}
