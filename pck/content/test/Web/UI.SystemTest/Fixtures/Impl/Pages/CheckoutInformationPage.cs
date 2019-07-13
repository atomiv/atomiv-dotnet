using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Impl.Pages
{
    public class CheckoutInformationPage : Page, ICheckoutInformationPage
    {
        public CheckoutInformationPage(Driver finder, bool navigateTo = false)
            : base(finder, PageUrl, navigateTo)
        {
        }

        public static string PageUrl = "https://www.saucedemo.com/checkout-step-one.html";

        private TextBox FirstNameTextBox => Finder.FindTextBox(FindBy.Id("first-name"));

        private TextBox LastNameTextBox => Finder.FindTextBox(FindBy.Id("last-name"));

        private TextBox ZipCodeTextBox => Finder.FindTextBox(FindBy.Id("postal-code"));

        private Button CancelButton => Finder.FindButton(FindBy.CssSelector(".cart_cancel_link"));

        private Button ContinueButton => Finder.FindButton(FindBy.CssSelector(".cart_button"));

        private Element ErrorElement => Finder.FindElement(FindBy.CssSelector("*[data-test='error']"));

        public void InputFirstName(string firstName)
        {
            FirstNameTextBox.EnterText(firstName);
        }

        public void InputLastName(string lastName)
        {
            LastNameTextBox.EnterText(lastName);
        }

        public void InputZipCode(string zipCode)
        {
            ZipCodeTextBox.EnterText(zipCode);
        }

        public void ClickCancel()
        {
            CancelButton.Click();
        }

        public void ClickContinue()
        {
            ContinueButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorElement.Text;
        }
    }
}
