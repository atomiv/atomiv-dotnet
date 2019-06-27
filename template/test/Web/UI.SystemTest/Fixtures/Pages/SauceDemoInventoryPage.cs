using FluentAssertions;
using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoInventoryPage : Page
    {
        public SauceDemoInventoryPage(Driver driver, bool navigateTo)
            : base(driver, "https://www.saucedemo.com/inventory.html", navigateTo)
        {
            Driver.Url.Should().Be(Url);
        }

        public ComboBox ProductSort => Driver.FindComboBox(FindType.ClassName, "product_sort_container");

        // TODO: VC: Do later

        // public List<InventoryItem> InventoryItems => Driver.FindElementCollection(FindType.ClassName, "inventory_item");
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
