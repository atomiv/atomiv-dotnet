using FluentAssertions;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
{
    public class SauceDemoInventoryTest : SauceDemoTest
    {
        private const string AddToCartText = "ADD TO CART";
        private const string RemoveText = "REMOVE";

        private static List<InventoryRecord> InventoryRecords = new List<InventoryRecord>
        {
            new InventoryRecord(0, "Sauce Labs Bike Light", 9.99m),
            new InventoryRecord(1, "Sauce Labs Bolt T-Shirt", 15.99m),
            new InventoryRecord(2, "Sauce Labs Onesie", 7.99m),
            new InventoryRecord(3, "Test.allTheThings() T-Shirt (Red)", 15.99m),
            new InventoryRecord(4, "Sauce Labs Backpack", 29.99m),
            new InventoryRecord(5, "Sauce Labs Fleece Jacket", 49.99m),
        };


        public SauceDemoInventoryTest(SauceDemoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void SelectInventoryItems()
        {
            var loginPage = Fixture.App.NavigateToLoginScreen();
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");

            var expectedInventoryItems = InventoryRecords.OrderBy(e => e.Name);

            var actualInventoryItems = inventoryPage.InventoryItems;

            actualInventoryItems.Count().Should().Be(expectedInventoryItems.Count());

            for(int i = 0; i < actualInventoryItems.Count(); i++)
            {
                var expectedInventoryItem = expectedInventoryItems.ElementAt(i);
                var actualInventoryItem = actualInventoryItems.ElementAt(i);

                actualInventoryItem.Name.Should().Be(expectedInventoryItem.Name);
                actualInventoryItem.Price.Should().Be(expectedInventoryItem.PriceText);
                actualInventoryItem.Action.Should().Be(AddToCartText);

                actualInventoryItem.Click();

                actualInventoryItem.Action.Should().Be(RemoveText);
            }

        }

        private class InventoryRecord
        {
            public InventoryRecord(int id, string name, decimal price)
            {
                Id = id;
                Name = name;
                PriceValue = price;
                PriceText = $"${price}";
            }

            public int Id { get; }

            public string Name { get; }

            public decimal PriceValue { get; }

            public string PriceText { get; }
        }
    }
}
