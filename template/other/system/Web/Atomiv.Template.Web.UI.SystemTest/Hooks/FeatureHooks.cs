using Atomiv.Template.Web.UI.SystemTest.Fixtures;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Atomiv.Template.Web.UI.SystemTest.Hooks
{
    [Binding]
    public sealed class FeatureHooks
    {
        private static WebFixture _webFixture;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        // NOTE: Method must be static // TODO: VC: Add to docs
        [BeforeFeature]
        public static async Task BeforeFeature()
        {
            _webFixture = new WebFixture();

            try
            {
                await _webFixture.Start();
            }
            catch (Exception)
            {
                _webFixture.Dispose();
                await _webFixture.EnsureNotRunning();

                throw;
            }
        }

        // NOTE: [AfterTestRun] is not working, so moved here to Feature, see https://github.com/techtalk/SpecFlow/issues/1348

        // NOTE: Method must be static // TODO: VC: Add to docs
        [AfterFeature]
        public static async Task AfterFeature()
        {
            _webFixture.Dispose();
            await _webFixture.EnsureNotRunning();
        }
    }
}