using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Platform.Test.Web.AspNetCore.Common
{
    public class TestServerFixture : IDisposable
    {
        public TestServerFixture(IWebHostBuilder webHostBuilder)
        {
            // TODO: VC: Check exception
            /*
System.IO.FileNotFoundException: 'Could not load file or assembly 'Microsoft.AspNetCore.Mvc, Version=2.2.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'. The system cannot find the file specified.'

             * 
             */


            TestServer = new TestServer(webHostBuilder);
            HttpClient = TestServer.CreateClient();
        }

        public TestServer TestServer { get; }

        public HttpClient HttpClient { get; }

        public void Dispose()
        {
            TestServer.Dispose();
            HttpClient.Dispose();
        }
    }
}
