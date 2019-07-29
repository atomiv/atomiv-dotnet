using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Records;
using System.Collections.Generic;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces
{
    public interface IProductPage
    {
        bool IsSortedByNameAsc();

        bool IsSortedByNameDesc();

        bool IsSortedByPriceAsc();

        bool IsSortedByPriceDesc();

        void SortByNameAsc();

        void SortByNameDesc();

        void SortByPriceAsc();

        void SortByPriceDesc();

        List<IProductComponent> GetProductComponents();

        List<IProductRecord> ReadProductRecords();

        IProductComponent GetProductComponentAtPosition(int position);
        
        void AddToCart(string productName);

        void ClickCart();
    }

    public interface IProductComponent
    {
        IProductRecord ReadProductRecord();

        bool CanAddToCart();

        bool CanRemoveFromCart();

        void AddToCart();

        void RemoveFromCart();
    }
}
