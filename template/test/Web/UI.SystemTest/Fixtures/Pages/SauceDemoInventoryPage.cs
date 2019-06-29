using FluentAssertions;
using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoInventoryPage : Page
    {
        public SauceDemoInventoryPage(Driver driver, bool navigateTo = false)
            : base(driver, "https://www.saucedemo.com/inventory.html", navigateTo)
        {
            Driver.Url.Should().Be(Url);
        }

        public ComboBox ProductSort => Driver.FindComboBox(FindBy.CssSelector(".product_sort_container"));

        // TODO: VC: Do later

        public IEnumerable<InventoryItem> InventoryItems => Driver.FindElements(FindBy.CssSelector(".inventory_item")).Select(e => new InventoryItem(e));
    }

    // TODO: VC: Container element

    public class InventoryItem : ElementObject
    {
        public InventoryItem(Element element) : base(element)
        {
        }

        public string Name => Element.WebElement.FindElement(By.ClassName("inventory_item_name")).Text;

        public string Description => Element.WebElement.FindElement(By.ClassName("inventory_item_desc")).Text;

        public string Price => Element.WebElement.FindElement(By.ClassName("inventory_item_price")).Text;

        // Sauce Labs Backpack


    }
}
