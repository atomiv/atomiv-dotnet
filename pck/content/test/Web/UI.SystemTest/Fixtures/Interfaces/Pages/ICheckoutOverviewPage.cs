using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Pages
{
    public interface ICheckoutOverviewPage
    {
        void ClickCancel();

        void ClickFinish();

        string GetCardNumber();

        string GetShippingInformation();

        decimal GetSubTotal();
    }
}
