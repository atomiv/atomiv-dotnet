using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces
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
