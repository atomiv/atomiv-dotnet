using FluentAssertions;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
{
    public class SauceDemoInventoryTest : SauceDemoTest
    {


        public SauceDemoInventoryTest(SauceDemoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void SelectInventoryItems()
        {
            var loginPage = Fixture.App.NavigateToLoginScreen();
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");

            var expectedInventoryItems = Fixture.Db.GetInventoryItemsOrderByNameAsc();

            var actualInventoryItems = inventoryPage.InventoryItems;

            actualInventoryItems.Count().Should().Be(expectedInventoryItems.Count());

            // TODO: VC: Create custom equals method on the wrapper to do comparison for the data, to avoid bulky tests
            // also move constants there too

            for(int i = 0; i < actualInventoryItems.Count(); i++)
            {
                var expectedInventoryItem = expectedInventoryItems.ElementAt(i);
                var actualInventoryItem = actualInventoryItems.ElementAt(i);

                actualInventoryItem.Data.Should().Be(expectedInventoryItem);

                actualInventoryItem.CanAddToCart.Should().BeTrue();
                actualInventoryItem.AddToCart();

                actualInventoryItem.CanRemoveFromCart.Should().BeTrue();

                // TODO: VC: Separate test for asserting state of adding and removing, separate from data correctness
            }

        }
    }
}
