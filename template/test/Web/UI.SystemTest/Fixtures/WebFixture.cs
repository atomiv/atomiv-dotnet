using System;
using System.IO;
using Optivem.Framework.Test.AspNetCore;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class WebFixture : IDisposable
    {
        public WebFixture()
        {
            var testDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var appRootPath = Path.GetFullPath(Path.Combine(testDirectoryPath, @"..\..\..\..\..\..\"));

            // TODO: VC: From config
            var srcRootPath = Path.GetFullPath(Path.Combine(appRootPath, @"src\"));

            var webApiDir = Path.Combine(srcRootPath, @"Web\RestApi");
            var webUiDir = Path.Combine(srcRootPath, @"Web\UI");

            var webApiFilePath = Path.Combine(webApiDir, "Optivem.Template.Web.RestApi.csproj");
            var webUiFilePath = Path.Combine(webUiDir, "Optivem.Template.Web.UI.csproj");

            var webApiPublishDir = Path.Combine(webApiDir, @"bin\Debug\netcoreapp2.2\publish");
            var webUiPublishDir = Path.Combine(webUiDir, @"bin\Debug\netcoreapp2.2\publish");



            // var webApiPublishDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            // var webUiPublishDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            var webApiDllName = "Optivem.Template.Web.RestApi.dll";
            var webUiDllName = "Optivem.Template.Web.UI.dll";

            // TOD: VC ftrom config
            var webApiUrl = "https://localhost:5103";
            var webUiUrl = "https://localhost:5109";

            var webApiPort = 5103;
            var webUiPort = 5109;

            // TODO: VC: from config
            // TODO: VC: Make PING methods, used for testing that api and application are alive and everything connected
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
            // TODO: VC: Async calls
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
