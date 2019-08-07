using System;
using System.Collections.Generic;
using System.Text;
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

            var srcRootPath = Path.GetFullPath(Path.Combine(appRootPath, @"src\"));
            var webApiProjectName = @"Web\RestApi\Optivem.Template.Web.RestApi.csproj";
            var webUiProjectName = @"Web\UI\Optivem.Template.Web.UI.csproj";

            var webApiPath = Path.Combine(srcRootPath, webApiProjectName);
            var webUiPath = Path.Combine(srcRootPath, webUiProjectName);

            var webApiUrl = "https://localhost:5001";
            var webUiUrl = "https://localhost:5003";

            // TODO: VC: Make PING methods, used for testing that api and application are alive and everything connected
            var webApiPingUrl = "swagger";
            var webUiPingUrl = "";

            var pinger = new WebPinger();

            WebApi = new WebProjectServer(webApiPath, webApiUrl, webApiPingUrl, pinger);
            WebUI = new WebProjectServer(webUiPath, webUiUrl, webUiPingUrl, pinger);
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
    }
}
