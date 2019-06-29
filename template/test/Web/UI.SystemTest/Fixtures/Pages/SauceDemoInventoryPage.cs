using FluentAssertions;
using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;
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

        public IEnumerable<InventoryItem> InventoryItems => Finder.FindElements<InventoryItem>(FindBy.CssSelector(".inventory_item"));
    }

    // TODO: VC: Container element

    public class InventoryItem : CompositeElement
    {
        private const string AddToCartText = "ADD TO CART";
        private const string RemoveFromCartText = "REMOVE";

        private const string IdPrefix = "item_";
        private const string IdSuffix = "_title_link";

        public InventoryItem(ElementRoot element) : base(element)
        {
        }

        private Element IdElement => Finder.FindElement(FindBy.CssSelector(".inventory_item_label > a"));

        private Element NameElement => Finder.FindElement(FindBy.CssSelector(".inventory_item_name"));

        private Element DescriptionElement => Finder.FindElement(FindBy.CssSelector(".inventory_item_desc"));

        private Element PriceElement => Finder.FindElement(FindBy.CssSelector(".inventory_item_price"));

        private Button CartButton => Finder.FindButton(FindBy.CssSelector(".btn_inventory"));

        public int Id
        {
            get
            {
                // TODO: VC: Create Anchor, which will have text and href
                // TODO: Add the id attribute to Element

                var idText = IdElement.GetAttributeValue("id");
                return GetId(idText);
            }
        }


        public string Name => NameElement.Text;

        public string Description => DescriptionElement.Text;

        public string Price => PriceElement.Text;

        public string CartAction => CartButton.Text;

        public bool CanAddToCart => CartAction == AddToCartText;

        public bool CanRemoveFromCart => CartAction == RemoveFromCartText;

        public InventoryItemRecord Data => new InventoryItemRecord(Id, Name, Price);

        public void AddToCart()
        {
            if(!CanAddToCart)
            {
                throw new InvalidElementStateException();
            }

            CartButton.Click();
        }

        public void RemoveFromCart()
        {
            if(!CanRemoveFromCart)
            {
                throw new InvalidElementStateException();
            }

            CartButton.Click();
        }

        public void Click()
        {
            CartButton.Click();
        }

        private static int GetId(string text)
        {
            var idStr = text
                .Replace(IdPrefix, string.Empty)
                .Replace(IdSuffix, string.Empty);

            var id = int.Parse(idStr);

            return id;

        }
    }


}
