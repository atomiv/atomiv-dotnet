using Optivem.Framework.Test.AspNetCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class WebFixture : IDisposable
    {
        public WebFixture()
        {
            var testDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var appRootPath = Path.GetFullPath(Path.Combine(testDirectoryPath, @"..\..\..\..\..\..\"));

            var srcRootPath = Path.GetFullPath(Path.Combine(appRootPath, @"src\"));

            var webApiDir = Path.Combine(srcRootPath, @"Web\Optivem.Template.Web.RestApi");
            var webUiDir = Path.Combine(srcRootPath, @"Web\Optivem.Template.Web.UI");

            var webApiFilePath = Path.Combine(webApiDir, "Optivem.Template.Web.RestApi.csproj");
            var webUiFilePath = Path.Combine(webUiDir, "Optivem.Template.Web.UI.csproj");

            var webApiPublishDir = Path.Combine(webApiDir, @"bin\Debug\netcoreapp2.2\publish");
            var webUiPublishDir = Path.Combine(webUiDir, @"bin\Debug\netcoreapp2.2\publish");

            var webApiDllName = "Optivem.Template.Web.RestApi.dll";
            var webUiDllName = "Optivem.Template.Web.UI.dll";

            var webApiUrl = "https://localhost:5103";
            var webUiUrl = "https://localhost:5109";

            var webApiPort = 5103;
            var webUiPort = 5109;

            var webApiPingUrl = "swagger";
            var webUiPingUrl = "";

            var pinger = new WebPinger();

            var webApiPaths = new WebProjectPaths(webApiDir, webApiFilePath, webApiPublishDir, webApiDllName);
            var webUiPaths = new WebProjectPaths(webUiDir, webUiFilePath, webUiPublishDir, webUiDllName);

            WebApi = new WebProjectServer(webApiPaths, webApiUrl, webApiPort, webApiPingUrl, pinger);
            WebUI = new WebProjectServer(webUiPaths, webUiUrl, webUiPort, webUiPingUrl, pinger);
        }

        public WebProjectServer WebApi { get; }

        public WebProjectServer WebUI { get; }

        public async Task Start()
        {
            await WebApi.Start();
            await WebUI.Start();
        }

        public void Dispose()
        {
            WebUI.Dispose();
            WebApi.Dispose();
        }

        public async Task EnsureNotRunning()
        {
            await WebUI.EnsureNotRunning();
            await WebApi.EnsureNotRunning();
        }
    }
}