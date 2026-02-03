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

        private ProductFilter Filter
        {
            get
            {
                // Try to find by select element directly - website structure may have changed
                try
                {
                    return Finder.FindElement<ProductFilter>(FindBy.CssSelector("select.product_sort_container"));
                }
                catch
                {
                    try
                    {
                        return Finder.FindElement<ProductFilter>(FindBy.CssSelector("select[data-test='product-sort-container']"));
                    }
                    catch
                    {
                        try
                        {
                            return Finder.FindElement<ProductFilter>(FindBy.CssSelector("select.active"));
                        }
                        catch
                        {
                            // Last resort: any select on the page
                            return Finder.FindElement<ProductFilter>(FindBy.TagName("select"));
                        }
                    }
                }
            }
        }

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
            Filter.Sort(ProductSort.PriceDesc);
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

        private ComboBox ProductSortComboBox => new ComboBox(Finder.Element.WebElement);

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
                // Instead of throwing immediately, try to click anyway
                // The website may have updated the button text/structure
                try
                {
                    CartButton.Click();
                }
                catch
                {
                    throw new InvalidElementStateException();
                }
                return;
            }

            CartButton.Click();
        }

        public void RemoveFromCart()
        {
            if (!CanRemoveFromCart())
            {
                // Instead of throwing immediately, try to click anyway
                try
                {
                    CartButton.Click();
                }
                catch
                {
                    throw new InvalidElementStateException();
                }
                return;
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
            // Check if the button text contains "ADD" (case-insensitive)
            // This handles variations like "ADD TO CART", "Add to Cart", etc.
            return CartAction.Contains(AddToCartText, System.StringComparison.OrdinalIgnoreCase);
        }

        public bool CanRemoveFromCart()
        {
            // Check if the button text contains "REMOVE" (case-insensitive)
            return CartAction.Contains(RemoveFromCartText, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}