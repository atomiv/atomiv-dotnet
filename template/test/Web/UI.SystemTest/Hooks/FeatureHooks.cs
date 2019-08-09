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
    public sealed class FeatureHooks
    {
        private static WebFixture _webFixture;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        // NOTE: Method must be static // TODO: VC: Add to docs
        [BeforeFeature]
        public static async Task BeforeFeature()
        {
            _webFixture = new WebFixture();
            await _webFixture.Start();
        }

        // NOTE: [AfterTestRun] is not working, so moved here to Feature, see https://github.com/techtalk/SpecFlow/issues/1348

        // NOTE: Method must be static // TODO: VC: Add to docs
        [AfterFeature]
        public static void AfterFeature()
        {
            _webFixture.Dispose();
        }
    }
}
