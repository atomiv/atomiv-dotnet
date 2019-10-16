using FluentAssertions;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Steps
{
    [Binding]
    public class CheckoutSteps : AppTest
    {
        public CheckoutSteps(AppFixture fixture) : base(fixture)
        {
        }

        #region Given

        [Given(@"I am logged with username '(.*)' and password '(.*)'")]
        public void GivenIAmLoggedWithUsernameAndPassword(string p0, string p1)
        {
            var loginPage = Fixture.App.OpenLoginPage();
            loginPage.InputUserName("standard_user");
            loginPage.InputPassword("secret_sauce");
            loginPage.ClickLogin();
        }

        [Given(@"I have added the product '(.*)' to the cart")]
        public void GivenIHaveAddedTheProductToTheCart(string productName)
        {
            var productPage = Fixture.App.GetProductPage();
            productPage.AddToCart(productName);
        }

        [Given(@"I have clicked on the cart")]
        public void GivenIHaveClickedOnTheCart()
        {
            var productPage = Fixture.App.GetProductPage();
            productPage.ClickCart();
        }

        [Given(@"I have clicked on checkout on the cart")]
        public void GivenIHaveClickedOnCheckoutOnTheCart()
        {
            var cartPage = Fixture.App.GetCartPage();
            cartPage.ClickCheckout();
        }

        [Given(@"I have entered the first name '(.*)'")]
        public void GivenIHaveEnteredTheFirstName(string firstName)
        {
            var informationPage = Fixture.App.GetCheckoutInformationPage();
            informationPage.InputFirstName(firstName);
        }

        [Given(@"I have entered the last name '(.*)'")]
        public void GivenIHaveEnteredTheLastName(string lastName)
        {
            var informationPage = Fixture.App.GetCheckoutInformationPage();
            informationPage.InputLastName(lastName);
        }

        [Given(@"I have entered the zip code '(.*)'")]
        public void GivenIHaveEnteredTheZipCode(string zipCode)
        {
            var informationPage = Fixture.App.GetCheckoutInformationPage();
            informationPage.InputZipCode(zipCode);
        }

        [Given(@"I have clicked on continue on the information")]
        public void GivenIHaveClickedOnContinueOnTheInformation()
        {
            var informationPage = Fixture.App.GetCheckoutInformationPage();
            informationPage.ClickContinue();
        }

        [Given(@"I see that the product '(.*)' has the price \$(.*)")]
        public void GivenISeeThatTheProductHasThePrice(string productName, Decimal productPrice)
        {
            var productPage = Fixture.App.GetProductPage();
            var product = productPage.GetProductComponents().Single(e => e.ReadProductRecord().Name == productName);
            product.ReadProductRecord().PriceValue.Should().Be(productPrice);
        }

        [Given(@"I see the card number '(.*)'")]
        public void GivenISeeTheCardNumber(string cardNumber)
        {
            var overviewPage = Fixture.App.GetCheckoutOverviewPage();
            overviewPage.GetCardNumber().Should().Be(cardNumber);
        }

        [Given(@"I see the shipping information '(.*)'")]
        public void GivenISeeTheShippingInformation(string shippingInformation)
        {
            var overviewPage = Fixture.App.GetCheckoutOverviewPage();
            overviewPage.GetShippingInformation().Should().Be(shippingInformation);
        }

        [Given(@"I see the subtotal \$(.*)")]
        public void GivenISeeTheSubtotal(Decimal subTotal)
        {
            var overviewPage = Fixture.App.GetCheckoutOverviewPage();
            overviewPage.GetSubTotal().Should().Be(subTotal);
        }

        #endregion Given

        #region When

        [When(@"I click on the Finish button on the overview")]
        public void WhenIClickOnTheFinishButtonOnTheOverview()
        {
            var overviewPage = Fixture.App.GetCheckoutOverviewPage();
            overviewPage.ClickFinish();
        }

        [When(@"I click on continue on the information")]
        public void WhenIClickOnContinueOnTheInformation()
        {
            var informationPage = Fixture.App.GetCheckoutInformationPage();
            informationPage.ClickContinue();
        }

        #endregion When

        #region Then

        [Then(@"I am on the order confirmation page")]
        public void ThenIAmOnTheOrderConfirmationPage()
        {
            var confirmationPage = Fixture.App.GetCheckoutConfirmationPage();
        }

        [Then(@"I see the confirmation header '(.*)'")]
        public void ThenISeeTheConfirmationHeader(string header)
        {
            var confirmationPage = Fixture.App.GetCheckoutConfirmationPage();
            confirmationPage.GetMessageHeader().Should().Be(header);
        }

        [Then(@"I see the confirmation text '(.*)'")]
        public void ThenISeeTheConfirmationText(string text)
        {
            var confirmationPage = Fixture.App.GetCheckoutConfirmationPage();
            confirmationPage.GetMessageText().Should().Be(text);
        }

        [Then(@"I see the error message for checkout information '(.*)'")]
        public void ThenISeeTheErrorMessageForCheckoutInformation(string errorMessage)
        {
            var informationPage = Fixture.App.GetCheckoutInformationPage();
            informationPage.GetErrorMessage().Should().Be(errorMessage);
        }

        #endregion Then
    }
}