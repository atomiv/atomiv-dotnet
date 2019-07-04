using FluentAssertions;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Optivem.Template.Web.UI.SystemTest.Steps
{
    [Binding]
    public class ProductSteps : AppTest
    {
        private IProductPage _productPage;

        public ProductSteps(AppFixture fixture) : base(fixture)
        {
        }

        #region Given

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            var loginPage = Fixture.App.OpenLoginPage();
            _productPage = loginPage.LoginAs("standard_user", "secret_sauce");
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

        #endregion
    }
}