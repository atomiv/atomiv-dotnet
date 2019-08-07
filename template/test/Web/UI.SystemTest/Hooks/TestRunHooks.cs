using Microsoft.Extensions.DependencyInjection;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Optivem.Template.Web.UI.SystemTest.Hooks
{
    [Binding]
    public sealed class TestRunHooks
    {
        private static WebFixture _webFixture;
        private static ServiceProvider _serviceProvider;

        static TestRunHooks()
        {
            _webFixture = new WebFixture();
        }

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            await _webFixture.Start();

            var services = new ServiceCollection();
            services.AddScoped<IAppFixture, AppFixture>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _serviceProvider.Dispose();

            _webFixture.Dispose();
        }
    }
}
