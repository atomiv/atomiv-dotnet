using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces
{
    public interface IApp
    {
        ILoginPage OpenLoginPage();

        IProductPage OpenProductPage();

        bool IsLoginPageOpen();

        bool IsProductPageOpen();
    }
}
