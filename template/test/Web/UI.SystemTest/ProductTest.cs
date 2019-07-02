using FluentAssertions;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
{
    public class ProductTest : AppTest
    {
        private IProductPage _productPage;

        public ProductTest(AppFixture fixture) : base(fixture)
        {
            var loginPage = Fixture.App.OpenLoginPage();
            _productPage = loginPage.LoginAs("standard_user", "secret_sauce");
        }

        // GIVEN I am on the products page
        // THEN the products should be sorted by product name (asc)
        [Fact]
        public void DefaultProductSortShouldBeNameAsc()
        {
            _productPage.IsSortedByNameAsc().Should().BeTrue();


        }

        // GIVEN I am on the products page
        // WHEN I sort the products by name in ascending order
        // THEN the products page should sort the products by name in ascending order

        [Fact]
        public void ProductSortByNameAsc()
        {
            _productPage.SortByNameAsc();

            var dbProducts = Fixture.Db.ReadProductsSortedByNameAsc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        // GIVEN I am on the products page
        // WHEN I sort the products by name in descending order
        // THEN the products page should sort the products by name in descending order

        [Fact]
        public void ProductSortByNameDesc()
        {
            _productPage.SortByNameDesc();

            var dbProducts = Fixture.Db.ReadProductsSortedByNameDesc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        // GIVEN I am on the products page
        // WHEN I sort the products by price in ascending order
        // THEN the products page should sort the products by price in ascending order

        [Fact]
        public void ProductSortByPriceAsc()
        {
            _productPage.SortByPriceAsc();

            var dbProducts = Fixture.Db.ReadProductsSortedByPriceAsc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        // GIVEN I am on the products page
        // WHEN I sort the products by price in descending order
        // THEN the products page should sort the products by price in descending order

        [Fact]
        public void ProductSortByPriceDesc()
        {
            _productPage.SortByPriceDesc();

            var dbProducts = Fixture.Db.ReadProductsSortedByPriceDesc();
            var pageProducts = _productPage.ReadProductRecords();

            pageProducts.Should().BeEquivalentTo(dbProducts);
        }

        // GIVEN I am on the products page
        // THEN all products can be added to the 
        [Fact]
        public void DefaultAllProductsCanBeAdded()
        {
            foreach(var productComponent in _productPage.GetProductComponents())
            {
                productComponent.CanAddToCart().Should().BeTrue();
            }
        }


        // GIVEN I am on the products page
        // WHEN I add the product to the cart
        // THEN I can remove the product from the cart
        [Fact]
        public void CanAddOneProduct()
        {
            var someProduct = _productPage.GetProductComponentAtPosition(2);

            someProduct.AddToCart();

            someProduct.CanRemoveFromCart().Should().BeTrue();
        }

        // GIVEN I am on the products page
        // AND I have added a product to the cart
        // WHEN I remove the product from the cart
        // THEN then product can be added again to the cart
        [Fact]
        public void CanRemoveAddedProduct()
        {
            var someProduct = _productPage.GetProductComponentAtPosition(3);

            someProduct.AddToCart();

            someProduct.RemoveFromCart();

            someProduct.CanAddToCart().Should().BeTrue();
        }

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
