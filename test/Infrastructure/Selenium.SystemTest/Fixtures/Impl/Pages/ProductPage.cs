using OpenQA.Selenium;
using Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Records;
using Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces;
using Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Records;
using System.Collections.Generic;
using System.Linq;

namespace Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages
{
    public class ProductPage : Page, IProductPage
    {
        public ProductPage(Driver finder, bool navigateTo = false)
            : base(finder, PageUrl, navigateTo)
        {
        }

        public static string PageUrl = "https://www.saucedemo.com/inventory.html";

        public static bool IsOpen(Driver finder)
        {
            return finder.Url == PageUrl;
        }

        private ProductFilter Filter => Finder.FindElement<ProductFilter>(FindBy.Id("inventory_filter_container"));

        private IEnumerable<ProductItem> Items => Finder.FindElements<ProductItem>(FindBy.CssSelector(".inventory_item"));

        private Element CartElement => Finder.FindElement(FindBy.CssSelector(".shopping_cart_link"));

        public IProductComponent GetProductComponentAtPosition(int position)
        {
            return Items.ElementAt(position - 1);
        }

        public List<IProductComponent> GetProductComponents()
        {
            return Items.Select(e => (IProductComponent)e).ToList();
        }

        public bool IsSortedByNameAsc()
        {
            return Filter.GetCurrentSort() == ProductSort.NameAsc;
        }

        public bool IsSortedByNameDesc()
        {
            return Filter.GetCurrentSort() == ProductSort.NameDesc;
        }

        public bool IsSortedByPriceAsc()
        {
            return Filter.GetCurrentSort() == ProductSort.PriceAsc;
        }

        public bool IsSortedByPriceDesc()
        {
            return Filter.GetCurrentSort() == ProductSort.PriceDesc;
        }

        public List<IProductRecord> ReadProductRecords()
        {
            var productComponents = GetProductComponents();
            return productComponents.Select(e => e.ReadProductRecord()).ToList();
        }

        public void SortByNameAsc()
        {
            Filter.Sort(ProductSort.NameAsc);
        }

        public void SortByNameDesc()
        {
            Filter.Sort(ProductSort.NameDesc);
        }

        public void SortByPriceAsc()
        {
            Filter.Sort(ProductSort.PriceAsc);
        }

        public void SortByPriceDesc()
        {
            Filter.Sort(ProductSort.PriceAsc);
        }

        public void AddToCart(string productName)
        {
            var products = GetProductComponents();
            var product = products.Single(e => e.ReadProductRecord().Name == productName);
            product.AddToCart();
        }

        public void ClickCart()
        {
            CartElement.WebElement.Click();
        }
    }

    // TODO: VC: Container element

    public class ProductFilter : CompositeElement
    {
        private static Dictionary<ProductSort, string> EnumValueMap
            = new Dictionary<ProductSort, string>
        {
            { ProductSort.NameAsc, "az" },
            { ProductSort.NameDesc, "za" },
            { ProductSort.PriceAsc, "lohi" },
            { ProductSort.PriceDesc, "hilo" },
        };

        private static Dictionary<string, ProductSort> ValueEnumMap
            = EnumValueMap.ToDictionary(e => e.Value, e => e.Key);

        public ProductFilter(ElementRoot finder) : base(finder)
        {
        }

        private ComboBox ProductSortComboBox => Finder.FindComboBox(FindBy.CssSelector(".product_sort_container"));

        public ProductSort GetCurrentSort()
        {
            var value = ProductSortComboBox.ReadSelectedValue();
            var sort = ValueEnumMap[value];
            return sort;
        }

        public void Sort(ProductSort sort)
        {
            var value = EnumValueMap[sort];
            ProductSortComboBox.SelectByValue(value);
        }
    }

    public enum ProductSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
    }

    public class ProductItem : CompositeElement, IProductComponent
    {
        private const string AddToCartText = "ADD TO CART";
        private const string RemoveFromCartText = "REMOVE";

        private const string IdPrefix = "item_";
        private const string IdSuffix = "_title_link";

        public ProductItem(ElementRoot element) : base(element)
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

        public void AddToCart()
        {
            if (!CanAddToCart())
            {
                throw new InvalidElementStateException();
            }

            CartButton.Click();
        }

        public void RemoveFromCart()
        {
            if (!CanRemoveFromCart())
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

        public IProductRecord ReadProductRecord()
        {
            return new ProductRecord(Id, Name, Price);
        }

        public bool CanAddToCart()
        {
            return CartAction == AddToCartText;
        }

        public bool CanRemoveFromCart()
        {
            return CartAction == RemoveFromCartText;
        }
    }
}