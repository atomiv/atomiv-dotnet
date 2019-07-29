using FluentAssertions;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces;
using TechTalk.SpecFlow;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Steps
{
    [Binding]
    public class ProductSteps : AppTest
    {
        private IProductPage _productPage;

        private IProductComponent _someProduct;

        public ProductSteps(AppFixture fixture) : base(fixture)
        {
        }

        #region Given

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            var loginPage = Fixture.App.OpenLoginPage();
            loginPage.InputUserName("standard_user");
            loginPage.InputPassword("secret_sauce");
            loginPage.ClickLogin();
            _productPage = Fixture.App.GetProductPage();
        }

        [Given(@"I have added a product to the cart")]
        public void GivenIHaveAddedAProductToTheCart()
        {
            _someProduct = _productPage.GetProductComponentAtPosition(2);
            _someProduct.AddToCart();
        }

        #endregion

        #region When

        [When(@"I select to sort the products by name \(asc\)")]
        public void WhenISelectToSortTheProductsByNameAsc()
        {
            _productPage.SortByNameAsc();
        }

        [When(@"I select to sort the products by name \(desc\)")]
        public void WhenISelectToSortTheProductsByNameDesc()
        {
            _productPage.SortByNameDesc();
        }

        [When(@"I select to sort the products by price \(asc\)")]
        public void WhenISelectToSortTheProductsByPriceAsc()
        {
            _productPage.SortByPriceAsc();
        }

        [When(@"I select to sort the products by price \(desc\)")]
        public void WhenISelectToSortTheProductsByPriceDesc()
        {
            _productPage.SortByPriceDesc();
        }

        [When(@"I click to add a product to the cart")]
        public void WhenIClickToAddAProductToTheCart()
        {
            _someProduct = _productPage.GetProductComponentAtPosition(2);
            _someProduct.AddToCart();
        }

        [When(@"I click to remove that product from the cart")]
        public void WhenIClickToRemoveThatProductFromTheCart()
        {
            _someProduct.RemoveFromCart();
        }

        #endregion

        #region Then

        [Then(@"I see the products sorted by name \(asc\)")]
        public void ThenISeeTheProductsSortedByNameAsc()
        {
            var dbProducts = Fixture.Db.ReadProductsSortedByNameAsc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        [Then(@"I see the products sorted by name \(desc\)")]
        public void ThenISeeTheProductsSortedByNameDesc()
        {
            var dbProducts = Fixture.Db.ReadProductsSortedByNameDesc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        [Then(@"I see the products sorted by price \(asc\)")]
        public void ThenISeeTheProductsSortedByPriceAsc()
        {
            var dbProducts = Fixture.Db.ReadProductsSortedByPriceAsc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        [Then(@"I see the products sorted by price \(desc\)")]
        public void ThenISeeTheProductsSortedByPriceDesc()
        {
            var dbProducts = Fixture.Db.ReadProductsSortedByPriceDesc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        [Then(@"It allows me to add all products")]
        public void ThenItAllowsMeToAddAllProducts()
        {
            foreach (var productComponent in _productPage.GetProductComponents())
            {
                productComponent.CanAddToCart().Should().BeTrue();
            }
        }

        [Then(@"that product has been added to the cart")]
        public void ThenThatProductHasBeenAddedToTheCart()
        {
            // TODO: VC: Counter has been incremented
            _someProduct.CanRemoveFromCart().Should().BeTrue();
        }

        [Then(@"that product has been removed from the cart")]
        public void ThenThatProductHasBeenRemovedFromTheCart()
        {
            // TODO: VC: Check counter
            _someProduct.CanAddToCart().Should().BeTrue();
        }

        #endregion





        // TODO: VC:
        // When I click on image it opens up product page
        // When I click on link it opens up product page
        // Product page contains same data as on the main page
        // I can add / remove the product from that product page
        // I can go back and it returns me to the main page, and the state is preserved there

        // When no products selected, cart has no number, and when I click on it it is empty
        // when I add one product, cart number is one, and when I click on it the one appears
        // when I have already added few products, and add another then card number is incremented by one and the list appears
        // on the cart page when I remove item it is removed from the cart number and also when I go back it is removed
        // when I click on back to shopping it takes me to shopping page
        // if I had already selected some, when shopping, and go back, state is preserved (incl. changes)

        // When I click on checkout it opens up the checkout page with first name, last name, zip
        // When I clickl on checkout, if I enter valid data then it takes me to checkout overview page
        // When I click on checkout, if I enter invalid then the error message is displayed (do error for missing firs tname, last name, post code)

        // Given I am on the checkout page it displays the previously selected data
        // checkout page correctluy shows subtotal, tax and total.. check also the quantities
        // if I click on cancel it takes me back
        // when I click on checkout it says thank yuou for your order


        // when I click on logout I am logged out

        // if I log in as locked out user, I get locked out error message
        // auth: missing username, missing passowrd, invalid combination


        // TODO: VC: Use perhaps nspec and show it on serbian in cyrillic
    }
}