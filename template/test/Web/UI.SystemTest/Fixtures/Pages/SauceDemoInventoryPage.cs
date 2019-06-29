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
        public SauceDemoInventoryPage(Driver finder, bool navigateTo = false)
            : base(finder, "https://www.saucedemo.com/inventory.html", navigateTo)
        {
        }

        public ComboBox ProductSort => Finder.FindComboBox(FindBy.CssSelector(".product_sort_container"));

        // TODO: VC: Do later

        public IEnumerable<InventoryItem> InventoryItems => Finder.FindElements(FindBy.CssSelector(".inventory_item"), e => new InventoryItem(e));
    }

    // TODO: VC: Container element

    public class InventoryItem : CompositeElement
    {
        public InventoryItem(ElementRoot element) : base(element)
        {
        }

        private Element NameElement => Finder.FindElement(FindBy.ClassName("inventory_item_name"));

        private Element DescriptionElement => Finder.FindElement(FindBy.ClassName("inventory_item_desc"));

        private Element PriceElement => Finder.FindElement(FindBy.ClassName("inventory_item_price"));

        public string Name => NameElement.Text;

        public string Description => DescriptionElement.Text;

        public string Price => PriceElement.Text;

        // Sauce Labs Backpack


    }
}
