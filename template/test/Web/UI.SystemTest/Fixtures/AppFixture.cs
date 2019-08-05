using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.AspNetCore;
using Optivem.Framework.Test.Selenium;
using Optivem.Template.Web.UI.Client;
using Optivem.Template.Web.UI.Client.Interface;
using System;
using System.Diagnostics;
using System.IO;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class AppFixture : IDisposable
    {
        public AppFixture()
        {
            var testDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var appRootPath = Path.GetFullPath(Path.Combine(testDirectoryPath, @"..\..\..\..\..\..\"));

            var srcRootPath = Path.GetFullPath(Path.Combine(appRootPath, @"src\"));
            var webApiProjectName = @"Web\RestApi\Optivem.Template.Web.RestApi.csproj";
            var webUiProjectName = @"Web\UI\Optivem.Template.Web.UI.csproj";

            var webApiPath = Path.Combine(srcRootPath, webApiProjectName);
            var webUiPath = Path.Combine(srcRootPath, webUiProjectName);

            WebApi = new WebProjectServer(webApiPath);
            WebUI = new WebProjectServer(webUiPath);

            WebApi.Start();
            WebUI.Start();

            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;

            var webUiUrl = "https://localhost:5003";

            App = new App(Driver, webUiUrl);
        }

        public WebProjectServer WebApi { get; }

        public WebProjectServer WebUI { get; }

        public ChromeDriverTestClient Client { get; }

        public Driver Driver { get; }

        public IApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();

            WebUI.Dispose();
            WebApi.Dispose();
        }
    }
}
