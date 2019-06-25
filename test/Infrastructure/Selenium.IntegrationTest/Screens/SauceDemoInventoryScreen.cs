using FluentAssertions;
using OpenQA.Selenium;
using Optivem.Framework.Test.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens
{
    public class SauceDemoInventoryScreen : TestScreen
    {
        private const string Url = "https://www.saucedemo.com/inventory.html";

        public SauceDemoInventoryScreen(TestDriver driver) 
            : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        public TestComboBox ProductSort => Driver.FindComboBoxByClass("product_sort_container");

        // TODO: VC: Do later

        // public List<InventoryItem> InventoryItems => Driver.FindElementCollection(FindType.ClassName, "inventory_item");


        public static SauceDemoInventoryScreen Open(TestDriver driver)
        {
            driver.Url = Url;
            return new SauceDemoInventoryScreen(driver);
        }
    }

    // TODO: VC: Container element

    public class InventoryItem : Element
    {
        public InventoryItem(IWebElement element) 
            : base(element)
        {
        }

        public string Name => WebElement.FindElement(By.ClassName("inventory_item_name")).Text;

        public string Description => WebElement.FindElement(By.ClassName("inventory_item_desc")).Text;

        public string Price => WebElement.FindElement(By.ClassName("inventory_item_price")).Text;

        // Sauce Labs Backpack

    }
}
